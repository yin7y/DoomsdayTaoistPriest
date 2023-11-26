using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UIManager
{
    static UIManager _instance;
    Transform _uiRoot;
    // 路徑配置字典
    Dictionary<string, string> pathDict;
    Dictionary<string, GameObject> prefabDict;
    public Dictionary<string, BasePanel> panelDict;
    
    public static UIManager Instance{
        get{
            if(_instance == null){
                _instance = new UIManager();
            }
            return _instance;
        }
    }
    public Transform UIRoot{
        get{
            if(_uiRoot == null){
                if(GameObject.Find("Canvas")){
                    _uiRoot = GameObject.Find("Canvas").transform;
                }else{
                    _uiRoot = new GameObject("Canvas").transform;
                }
            };
            return _uiRoot;
        }
    }
    UIManager(){
        InitDicts();
    }
    void InitDicts(){
        prefabDict = new Dictionary<string, GameObject>();
        panelDict = new Dictionary<string, BasePanel>();
        
        pathDict = new Dictionary<string, string>(){
            {UIConst.PackagePanel, "Package/PackagePanel"},
        };
    }
    public BasePanel GetPanel(string name){
        BasePanel panel = null;
        // 檢查是否已打開
        if(panelDict.TryGetValue(name, out panel)){
            return panel;
        }
        return null;
    }
    public BasePanel OpenPanel(string name){
        BasePanel panel = null;
        // 檢查是否已打開
        if(panelDict.TryGetValue(name, out panel)){
            Debug.Log("介面已打開: " + name);
            return null;
        }
        // 檢查路徑是否配置
        string path = "";
        if(!pathDict.TryGetValue(name, out path)){
            Debug.Log("介面名稱錯誤, 或未配置路徑: " + name);
            return null;
        }
        // 使用緩存的預製件
        GameObject panelPrefab = null;
        if(!prefabDict.TryGetValue(name, out panelPrefab)){
            string realPath = "Prefab/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }
        // 打開介面
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        return panel;
    }
    // 關閉介面
    public bool ClosePanel(string name){
            BasePanel panel = null;
            if(!panelDict.TryGetValue(name, out panel)){
                Debug.LogError("介面未打開:  " + name);
                return false;
            }
            panel.ClosePanel();
            return true;
    }    
}
public class UIConst{
    // menu panels
    public const string PackagePanel = "PackagePanel";
}
using System.Collections.Generic;
using UnityEngine;
public class PackageLocalData
{
    static PackageLocalData _instance;    
    public static PackageLocalData Instance
    {
        get{
            if(_instance == null){
                _instance = new PackageLocalData();
            }
            return _instance;
        }
    }
    
    public List<PackageLocalItem> items;
    
    public void SavePackage(){
        string inventoryJson = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("PackageLocalData", inventoryJson);
        PlayerPrefs.Save();
    }
    public List<PackageLocalItem> LoadPackage()
    {
        if(items != null)
            return items;
        if(PlayerPrefs.HasKey("PackageLocalData")){
            string inventoryJson = PlayerPrefs.GetString("PackageLocalData");
            PackageLocalData packageLocalData = JsonUtility.FromJson<PackageLocalData>(inventoryJson);
            items = packageLocalData.items;
            return items;
        }else{
            items = new List<PackageLocalItem>();
            return items;
        }
    }
}

[System.Serializable]
public class PackageLocalItem
{
    public string uid;
    public int id, num, level;
    public bool isNew;

    public override string ToString()
    {
        return string.Format("[id]:{0}, [name]:{1}", id, num);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;


public class GMCmd
{
    [MenuItem("GMCmd/讀取表格")]
    public static void ReadTable(){
        PackageTable packageTable = Resources.Load<PackageTable>("TableData/PackageTable");
        foreach(PackageTableItem packageItem in packageTable.DataList){
            Debug.Log(string.Format("【id】:{0}, 【name】:{1}", packageItem.id, packageItem.name));
        }
    }
    [MenuItem("GMCmd/創建背包測試數據")]
    public static void CreateLocalPackageData(){
        // Save
        PackageLocalData.Instance.items = new List<PackageLocalItem>();
        for(int i = 1; i < 9; i++){
            PackageLocalItem packageLocalItem = new()
            {
                uid = Guid.NewGuid().ToString(),
                id = i,
                num = i,
                level = i,
                isNew = i % 2 == 1
            };
            PackageLocalData.Instance.items.Add(packageLocalItem);
        }
        PackageLocalData.Instance.SavePackage();
        
    }
    [MenuItem("GMCmd/讀取背包測試數據")]
    public static void ReadLocalPackageData(){
        // Read
        List<PackageLocalItem> readItems = PackageLocalData.Instance.LoadPackage();
        foreach(PackageLocalItem item in readItems){
            Debug.Log(item);
        }
    }
    [MenuItem("GMCmd/打開背包主介面")]
    public static void OpenPackagePanel(){
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);
    }
}

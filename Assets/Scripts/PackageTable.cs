using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "7uuuuu/PackageTable", fileName = "PackageTable")]

public class PackageTable : ScriptableObject
{
    public List<PackageTableItem> DataList = new List<PackageTableItem>();
}

[System.Serializable]
public class PackageTableItem
{
    public int id, type, rate;
    public string name, description, skillDescription, imagePath;
    public int num;
}

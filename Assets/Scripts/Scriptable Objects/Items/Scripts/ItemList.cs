using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Mines,
}
public abstract class ItemList : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}

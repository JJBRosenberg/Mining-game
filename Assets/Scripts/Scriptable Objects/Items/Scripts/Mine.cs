using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mine", menuName = "inventory System/items/Mine")]

public class Mine : ItemList
{
    public int damageTaken;
    public void Awake()
    {
        type = ItemType.Mines;
        
    }
}

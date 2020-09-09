using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] public string[] toolsToUse;
    [SerializeField] private int toolIndex;


    public void SetToolIndex(int value)
    {
        toolIndex = value;
    }

    public int GetNeededToolIndex()
    {
        return toolIndex;
    }

    public int GetLastToolIndex()
    {
        return toolsToUse.Length;
    }

}

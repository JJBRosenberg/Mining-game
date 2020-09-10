using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] public string[] toolsToUse;
    [SerializeField] private bool isFinished;
    [SerializeField] private GameObject[] mineModels;
    [SerializeField] private int toolIndex;

    

    public void SetToolIndex(int value)
    {
        toolIndex = value;
        if (toolIndex > 0 && toolIndex < GetLastToolIndex())
        {
            mineModels[toolIndex].SetActive(true);
            mineModels[toolIndex - 1].SetActive(false);
        }
    }

    public int GetNeededToolIndex()
    {
        return toolIndex;
    }

    public void SetFinished(bool value)
    {
        isFinished = value;
    }

    public bool GetFinished()
    {
        return isFinished;
    }
    
    public int GetLastToolIndex()
    {
        return toolsToUse.Length;
    }

}

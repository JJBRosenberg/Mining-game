﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int minesCount = 0;
    [SerializeField] private List<GameObject> mines;
    [SerializeField] private string currentToolUsed;
    public static Manager GetManager()
    {
        return manager;
    }
    
    private static Manager manager;
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            minesCount = 0;
            mines = GameObject.FindGameObjectsWithTag("Mine").ToList();
            DontDestroyOnLoad(manager);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void AddMinesCount()
    {
        minesCount++;
    }

    public void SetCurrentToolUsed(string name)
    {
        currentToolUsed = name;
    }

    public void ResetMinesCount()
    {
        minesCount = 0;
    }
    
    public string GetCurrentToolUsed()
    {
        return currentToolUsed;
    }
    
    public int GetMinesCount()
    {
        return minesCount;
    }

    public void RemoveMine(GameObject mine)
    {
        Destroy(mine);
        mines.Remove(mine);
    }
    

}

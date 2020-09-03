using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int minesCount = 0;
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
            DontDestroyOnLoad(manager);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMinesCount()
    {
        minesCount++;
    }

    public int GetMinesCount()
    {
        return minesCount;
    }

}

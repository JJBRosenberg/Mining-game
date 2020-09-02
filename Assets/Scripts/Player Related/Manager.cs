using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void AddMinesCount()
    {
        minesCount++;
    }

    public int GetMinesCount()
    {
        return minesCount;
    }

}

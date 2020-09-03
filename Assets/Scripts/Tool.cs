using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int index;
    [SerializeField] private string name;
    [SerializeField] private Sprite toolSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetIndex()
    {
        return index;
    }

    public string GetName()
    {
        return name;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public enum ToolName
    {
        Pliers,
        WireCutter
    };
    // Start is called before the first frame update
    [SerializeField] private int index;
    [SerializeField] private string name;
    [SerializeField] private Sprite toolSprite;
    //[SerializeField] private ToolName toolName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public ToolName GetIndex()
    // {
    //     return toolName;
    // }

    public string GetName()
    {
        return name;
    }
    
}

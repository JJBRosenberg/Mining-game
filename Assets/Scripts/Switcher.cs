using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int currentTool;
    //[SerializeField] public List<Tool> tools;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int previousTool = currentTool;
        
        ChangeWithScroll();
        ChangeWithKeyPress();

        if (previousTool != currentTool)
        {
            SwitchTool();
        }
    }

    void ChangeWithKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTool = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            currentTool = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            currentTool = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            currentTool = 3;
        }

    }
    
    void ChangeWithScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentTool >= transform.childCount - 1)
            {
                currentTool = 0;
            }

            currentTool++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentTool <= 0)
            {
                currentTool = transform.childCount - 1;
            }

            currentTool--;
        }
    }
    
    public void SwitchTool()
    {
        int i = 0;

        foreach (Transform tool in transform)
        {
            if (i == currentTool)
            {
                tool.gameObject.SetActive(true);
            }
            else
            {
                tool.gameObject.SetActive(false);
            }
            i++;
        }
        
    }

    // public void AddTool(Tool t)
    // {
    //     tools.Add(t);
    // }

    public void SetCurrentToolIndex(int value)
    {
        currentTool = value;
    }

}

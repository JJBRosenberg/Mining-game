using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int maxMinesCount;
    [SerializeField] private Text text;
    [SerializeField] private GameObject textToHide;
    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "Mines left: " + Manager.GetManager().GetMinesCount();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Manager.GetManager().GetMinesCount() >= maxMinesCount)
        {
            //win condition
        }
        else if (Manager.GetManager().GetMinesCount() < maxMinesCount)
        {
            //not yet win condition
        }
        textToHide.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        textToHide.SetActive(false);
    }
}

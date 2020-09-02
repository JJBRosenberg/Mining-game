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
    //[SerializeField] private Transform player;

    private void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        // player.position = transform.position;
    }


    private void Update()
    {
        if (Manager.GetManager().GetMinesCount() < maxMinesCount)
        {
            text.text = "Mines left: " + (maxMinesCount - Manager.GetManager().GetMinesCount());
        }
        else
        {
            text.text = "VERI GUD U WIN";
        }
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

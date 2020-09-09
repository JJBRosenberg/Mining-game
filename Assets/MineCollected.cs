using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineCollected : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int maxMinesCount, sceneIndex;
    [SerializeField] private Text minesLeftText;
    [SerializeField] private GameObject textToHide;
    [SerializeField] public Canvas canvas;
    [SerializeField] private bool isInArea;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] mines;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = transform.position;
        mines = GameObject.FindGameObjectsWithTag("Mine");
        maxMinesCount = mines.Length;
    }


    private void Update()
    {
        if (isInArea)
        {
            if (Manager.GetManager().GetMinesCount() < maxMinesCount)
            {
                // minesLeftText.text = "Mines left: " + (maxMinesCount - Manager.GetManager().GetMinesCount());
                //canvas.SetActive(true);
            }
            else
            {
                //GameObject.FindGameObjectWithTag("Player").SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Manager.GetManager().ResetMinesCount();
                SceneManage.GoToScene(sceneIndex);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        isInArea = true;
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
        isInArea = false;
        textToHide.SetActive(false);
    }
}

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
                text.text = "Mines left: " + Manager.GetManager().GetMinesCount();
                Debug.Log(Manager.GetManager().GetMinesCount());
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Cursor.lockState = CursorLockMode.None;
                SceneManage.GoToScene(3);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Manager.GetManager().GetMinesCount() >= maxMinesCount)
        {
            //win condition
            isInArea = true;
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

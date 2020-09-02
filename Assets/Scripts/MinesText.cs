using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text minesText;
    void Start()
    {
        //minesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        minesText.text = "Mines collected: " 
                         + Manager.GetManager().GetMinesCount();
    }
}

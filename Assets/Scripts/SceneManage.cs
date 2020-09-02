using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    public static void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}

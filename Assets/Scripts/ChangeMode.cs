using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMode : MonoBehaviour {

    public void easyMode()
    {
        SceneManager.LoadScene("EasyMode");
    }

    public void hardMode()
    {
        SceneManager.LoadScene("HardMode");
    }
}

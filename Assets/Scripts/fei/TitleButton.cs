using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButton : MonoBehaviour
{
    public string sceneToload = "";
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToload);
    }
}

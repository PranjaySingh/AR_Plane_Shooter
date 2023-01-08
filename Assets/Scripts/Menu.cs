using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class Menu : MonoBehaviour
{
    public void StartBtn()
    {
        LoaderUtility.Initialize();
        SceneManager.LoadScene("Game");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}

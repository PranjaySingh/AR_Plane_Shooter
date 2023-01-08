using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameOver : MonoBehaviour
{
    public Player player;
    public ARSession arSession;

    private void Awake()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("MainCamera").GetComponent<Player>();
        }
    }
    public void Restart()
    {
        gameObject.SetActive(false);
        player.health = 4;
        Time.timeScale = 1;


        LoaderUtility.Deinitialize();
        LoaderUtility.Initialize();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        if (arSession)
        {
            arSession.Reset();
        }
        Time.timeScale = 1;
        LoaderUtility.Deinitialize();
        SceneManager.LoadScene("Menu");
    }
}

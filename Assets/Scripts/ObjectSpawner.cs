using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private float spawnInterval = 4f;
    [SerializeField] Camera arCamera;

    private void Start()
    {
        if (arCamera == null)
        {
                arCamera = Camera.main;   
        }
    }

    public void StartBtn()
    {
        if (arCamera == null)
        {
            arCamera = Camera.main;
        }

        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(spawnInterval);

        Vector3 screenPosition = arCamera.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width),
                                                                         Random.Range(0, Screen.height),
                                                                         distanceFromPlayer));
        Instantiate(objectToSpawn, screenPosition, Quaternion.identity);
        StartCoroutine(StartSpawning());
    }
}
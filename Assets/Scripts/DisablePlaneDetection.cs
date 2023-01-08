using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DisablePlaneDetection : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    private ARPlaneManager arPlaneManager;

    private void Awake()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    public void DisablePlaneDetect()
    {
        arPlaneManager.enabled = false;
        arRaycastManager.enabled = false;
    }
}

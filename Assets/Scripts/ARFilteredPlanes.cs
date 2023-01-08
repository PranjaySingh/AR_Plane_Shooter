using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFilteredPlanes : MonoBehaviour
{
    [SerializeField] private Vector2 bigPlaneDimension = new Vector2(5f, 5f);
    private ARPlaneManager arPlaneManager;
    private List<ARPlane> arPlanes;

    public event Action OnBigplaneFound;

    private void OnEnable()
    {
        arPlanes = new List<ARPlane>();
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if(args.added != null && args.added.Count > 0)
        {
            arPlanes.AddRange(args.added);
        }

        foreach(ARPlane plane in arPlanes)
        {
            if(plane.extents.x * plane.extents.y >= bigPlaneDimension.x * bigPlaneDimension.y)
            {
                OnBigplaneFound.Invoke();
            }
        }
    }
}

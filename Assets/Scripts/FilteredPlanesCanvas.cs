using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilteredPlanesCanvas : MonoBehaviour
{
    [SerializeField] private Toggle bigPlaneToggle;
    [SerializeField] private Button startButton;

    private ARFilteredPlanes arFilteredPlanes;

    public bool BigPlaneToggle
    {
        get => bigPlaneToggle.isOn;
        set
        {
            bigPlaneToggle.isOn = value;
            CheckIfTrue();
        }
    }

    private void OnEnable()
    {
        arFilteredPlanes = FindObjectOfType<ARFilteredPlanes>();
        arFilteredPlanes.OnBigplaneFound += () => BigPlaneToggle = true;
    }

    private void OnDisable()
    {
        arFilteredPlanes.OnBigplaneFound -= () => BigPlaneToggle = true;
    }

    private void CheckIfTrue()
    {
        if (BigPlaneToggle)
        {
            startButton.interactable = true;
        }
    }
}
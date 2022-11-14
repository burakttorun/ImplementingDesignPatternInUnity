using System;
using System.Collections;
using System.Collections.Generic;
using ThePrototype.Scripts.Command;
using UnityEngine;
using Random = UnityEngine.Random;

public class InputGround : MonoBehaviour
{
    private Camera _mainCamera;
    private RaycastHit _hitInfo;
    public Transform cubePrefab;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hitInfo, 100))
        {
            Color color = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
            CommandInvoker.AddCommand(new PlaceCubeCommand(_hitInfo.point, color, cubePrefab));
        }
    }
}
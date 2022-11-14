using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MethodManager
{
    static List<Transform> _cubes;

    public static void PlaceCube(Vector3 position, Color color, Transform cube)
    {
        Transform createdCube = GameObject.Instantiate(cube, position, Quaternion.identity);
        createdCube.GetComponentInChildren<MeshRenderer>().material.color = color;

        if (_cubes == null)
        {
            _cubes = new List<Transform>();
        }

        _cubes.Add(createdCube);
    }

    public static void RemoveCube(Vector3 position, Color color)
    {
        for (int i = 0; i < _cubes.Count; i++)
        {
            if (_cubes[i].position == position
                && _cubes[i].GetComponentInChildren<MeshRenderer>().material.color == color)
            {
                GameObject.Destroy(_cubes[i].gameObject);
                _cubes.RemoveAt(i);
            }
        }
    }
}
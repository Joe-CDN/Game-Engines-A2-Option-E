using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    static List<Transform> cubes;

    public static void PlaceCube(Vector3 position, Transform cube)
    {
        Transform newCube = Instantiate(cube, position, Quaternion.identity);
        //newCube.GetComponentInChildren<MeshRenderer>().material.color = color;
        if (cubes == null){
            cubes = new List<Transform>();
        }
        cubes.Add(newCube);
    }

    public static void RemoveCube(Vector3 position)
    {
        for (int i = 0; i < cubes.Count; i++){
            if (cubes[i].position == position) 
            {
                GameObject.Destroy(cubes[i].gameObject);
                cubes.RemoveAt(i);
                break;
            }
        }
    }
}

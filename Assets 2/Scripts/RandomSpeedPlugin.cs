using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class RandomSpeedPlugin : MonoBehaviour
{
    [DllImport("RandomSpeed")]
    private static extern float RandomizeSpeed();

    // Start is called before the first frame update
    void Start()
    {
        Move.movespeed = RandomizeSpeed();
    }
}

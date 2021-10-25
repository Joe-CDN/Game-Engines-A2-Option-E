using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform capsule;
    public Transform spike;

    private int spawnID;
    private float timer;
    private float timerDuration = 0.50f;

    private void Start()
    {
        timer = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Vector3 position = new Vector3(Random.Range(-9.0f,9.0f), this.transform.position.y, 0);
        spawnID = Random.Range(0, 2);

        if(timer<=0)
        {
            if(spawnID==0)
            {
                ICommand command = new PlaceCubeCommand(position, capsule);
                CommandInvoker.AddCopmmand(command);
                timer = timerDuration;
            }
            else
            {
                ICommand command = new PlaceCubeCommand(position, spike);
                CommandInvoker.AddCopmmand(command);
                timer = timerDuration;
            }
           
        }
        /*
         *  ICommand command = new PlaceCubeCommand(hitInfo.point, cubePrefab);
                    CommandInvoker.AddCopmmand(command);
         */
    }
}

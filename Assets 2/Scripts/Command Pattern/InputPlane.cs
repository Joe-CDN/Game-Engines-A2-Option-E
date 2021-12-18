using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform cubePrefab;
    public Transform PlankPrefab;
    public Transform PlankTallPrefab;
    public Transform Plank30CWPrefab;
    public Transform Plank30CCWPrefab;
    public Transform spikePrefab;

    public static bool editMode = false;

    private int spawnID;

    // Start is called before the first frame update
    void Awake()
    {
        maincam = Camera.main;
        spawnID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && editMode == true && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                //Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);
                if(spawnID == 0)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, cubePrefab);
                    CommandInvoker.AddCopmmand(command);
                }                
                if(spawnID == 1)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, PlankPrefab);
                    CommandInvoker.AddCopmmand(command);
                }  
                if(spawnID == 2)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, PlankTallPrefab);
                    CommandInvoker.AddCopmmand(command);
                }
                if(spawnID == 3)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, Plank30CWPrefab);
                    CommandInvoker.AddCopmmand(command);
                }
                if(spawnID == 4)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, Plank30CCWPrefab);
                    CommandInvoker.AddCopmmand(command);
                }
                if(spawnID == 5)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, spikePrefab);
                    CommandInvoker.AddCopmmand(command);
                } 
                
            }
        }
        
    }

    public void HandleInputData(int val)
    {
        if(val == 0)
        {
            spawnID = 0;
        }
        if(val == 1)
        {
            spawnID = 1;
        }
        if(val == 2)
        {
            spawnID = 2;
        }
        if(val == 3)
        {
            spawnID = 3;
        }
        if(val == 4)
        {
            spawnID = 4;
        }
        if(val == 5)
        {
            spawnID = 5;
        }
    }
    public void ToggleEditMode()
    {
        editMode = !editMode;
    }
}

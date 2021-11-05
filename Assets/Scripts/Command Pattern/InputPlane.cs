using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

[System.Serializable]
public class InputPlane : MonoBehaviour, ISaveable
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform cubePrefab;
    public Transform PlankPrefab;
    public Transform PlankTallPrefab;
    public Transform Plank30CWPrefab;
    public Transform Plank30CCWPrefab;
    public Transform spikePrefab;
    public Transform goalPrefab;

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
                    ICommand command = new PlaceCubeCommand(hitInfo.point, cubePrefab, "cube");
                    CommandInvoker.AddCopmmand(command);
                }                
                if(spawnID == 1)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, PlankPrefab, "plank");
                    CommandInvoker.AddCopmmand(command);
                }  
                if(spawnID == 2)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, PlankTallPrefab, "wall");
                    CommandInvoker.AddCopmmand(command);
                }
                if(spawnID == 3)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, Plank30CWPrefab, "cwPlank");
                    CommandInvoker.AddCopmmand(command);
                }
                if(spawnID == 4)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, Plank30CCWPrefab, "ccwPlank");
                    CommandInvoker.AddCopmmand(command);
                }
                if(spawnID == 5)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, spikePrefab, "spike");
                    CommandInvoker.AddCopmmand(command);
                }
                if(spawnID == 6)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, goalPrefab, "end");
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
        if(val == 6)
        {
            spawnID = 6;
        }
    }
    public void ToggleEditMode()
    {
        editMode = !editMode;
    }

    //Saving and Loading level
    public void SaveLevel()
    {
        SaveJsonData(this);
    }
    public void LoadLevel()
    {
        LoadJsonData(this);
    }

    private static void SaveJsonData(InputPlane a_InputPlane)
    {
        LevelData ld = new LevelData();
        a_InputPlane.PopulateSaveData(ld);

        if(FileManager.WriteToFile("SaveData.dat", ld.ToJson()))
        {
            Debug.Log("Save Successful");
        }
    }

    public void PopulateSaveData(LevelData a_saveData)
    {
        for (int i = 0; i < CubePlacer.cubes.Count; i++)
        {
            a_saveData.m_shapeNames.Add(CubePlacer.names[i]);
            a_saveData.m_shapes.Add(CubePlacer.cubes[i]);            
        }
    }

    private static void LoadJsonData(InputPlane a_InputPlane)
    {
        if(FileManager.LoadFromFile("SaveData.dat", out var json))
        {
            LevelData ld = new LevelData();
            ld.LoadFromJson(json);

            a_InputPlane.LoadFromSaveData(ld);
            Debug.Log("Load Complete");
        }
    }

    public void LoadFromSaveData(LevelData a_saveData)
    {
        for (int i = 0; i < a_saveData.m_shapes.Count; i++)
        {
            //CubePlacer.cubes.Add(a_saveData.m_shapes[i]);
            
            if(a_saveData.m_shapeNames[i] == "cube"){
                ICommand command = new PlaceCubeCommand(a_saveData.m_shapes[i].position, cubePrefab, "cube");
                CommandInvoker.AddCopmmand(command);
            }
            if(a_saveData.m_shapeNames[i] == "plank"){
                ICommand command = new PlaceCubeCommand(a_saveData.m_shapes[i].position, PlankPrefab, "plank");
                CommandInvoker.AddCopmmand(command);
            }
            if(a_saveData.m_shapeNames[i] == "wall"){
                ICommand command = new PlaceCubeCommand(a_saveData.m_shapes[i].position, PlankTallPrefab, "wall");
                CommandInvoker.AddCopmmand(command);
            }
            if(a_saveData.m_shapeNames[i] == "cwPlank"){
                ICommand command = new PlaceCubeCommand(a_saveData.m_shapes[i].position, Plank30CWPrefab, "cwPlank");
                CommandInvoker.AddCopmmand(command);
            }
            if(a_saveData.m_shapeNames[i] == "ccwPlank"){
                ICommand command = new PlaceCubeCommand(a_saveData.m_shapes[i].position, Plank30CCWPrefab, "ccwPlank");
                CommandInvoker.AddCopmmand(command);
            }
            if(a_saveData.m_shapeNames[i] == "spike"){
                ICommand command = new PlaceCubeCommand(a_saveData.m_shapes[i].position, spikePrefab, "spike");
                CommandInvoker.AddCopmmand(command);
            }
            if(a_saveData.m_shapeNames[i] == "end"){
                ICommand command = new PlaceCubeCommand(a_saveData.m_shapes[i].position, goalPrefab, "end");
                CommandInvoker.AddCopmmand(command);
            }
        }
    }
}

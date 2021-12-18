using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubeCommand : ICommand
{
    Vector3 position;
    Color color;
    Transform cube;

    public PlaceCubeCommand(Vector3 position, Transform cube)
    {
        this.position = position;
        this.cube = cube;
    }
    
    public void Execute()
    {
        CubePlacer.PlaceCube(position, cube);
    }

    public void Undo()
    {
        CubePlacer.RemoveCube(position);
    }
}

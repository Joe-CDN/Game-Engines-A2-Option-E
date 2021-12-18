using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubeCommand : ICommand
{
    Vector3 position;
    Color color;
    Transform cube;
    string name;

    public PlaceCubeCommand(Vector3 position, Transform cube, string name)
    {
        this.position = position;
        this.cube = cube;
        this.name = name;
    }
    
    public void Execute()
    {
        CubePlacer.PlaceCube(position, cube, name);
    }

    public void Undo()
    {
        CubePlacer.RemoveCube(position);
    }
    public override string ToString()
    {
        return "PlaceCurve:\t" + position.x + ":" + position.y + ":" + position.z + "\t"
            + color.r + ":" + color.g + ":" + color.b;
    }
}

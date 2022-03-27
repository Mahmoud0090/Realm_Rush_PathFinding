using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int coordinate;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

}

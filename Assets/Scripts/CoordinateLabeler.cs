using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    //this class only execute in edit mode , and 
    //when building the game this script must be in Editor folder in unity 
    //as all files in that folder are ignored when building the game

    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.white;

    [SerializeField] Color exploredtColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f , 0.5f , 0f); //orange color

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>(); 
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        DisplayCoordinates();
    }

    void Update()
    {
        
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    void SetLabelColor()
    {
        if(gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if(node == null) { return; }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }

        else if (node.isPath)
        {
            label.color = pathColor;
        }

        else if (!node.isExplored)
        {
            label.color = exploredtColor;
        }
        else
        {
            label.color = defaultColor;
        }
    
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void DisplayCoordinates()
    {
        //the two lines below are using unityeditor functionality and this will not work when building the game
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + " , " + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}

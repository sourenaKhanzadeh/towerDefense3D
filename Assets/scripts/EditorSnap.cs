using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] float gridSize = 10f;

    private Waypoint waypoint;
    private Vector3 snapPos;

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
        UpdateScale();

    }

    private void SnapToGrid() {
        int gridSize = waypoint.GetGridSize();
        snapPos = new Vector3(waypoint.GetGridPos().x,
            0,waypoint.GetGridPos().y);

        transform.position = snapPos;
    }

    private void UpdateLabel() {
        string coord_text = snapPos.z / gridSize + "," + snapPos.x / gridSize;

        TextMesh coordinate = GetComponentInChildren<TextMesh>();
        coordinate.text = coord_text;
        gameObject.name = coord_text;

    }

    private void UpdateScale() {
        Vector3 scale = new Vector3(1f, 1f, 1f) * gridSize;
        transform.localScale = scale;    

    }
}


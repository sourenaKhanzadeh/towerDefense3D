using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] float gridSize = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos = new Vector3(0,0,0);
        Vector3 scale = new Vector3(1f, 1f, 1f) * gridSize;


        transform.localScale = scale;

        snapPos.x = Mathf.RoundToInt(transform.position.x / 
            gridSize) * gridSize;

        snapPos.z = Mathf.RoundToInt(transform.position.z/gridSize)*gridSize;

        string coord_text = snapPos.z / gridSize + "," + snapPos.x / gridSize;

        TextMesh coordinate = GetComponentInChildren<TextMesh>();
        coordinate.text = coord_text;
        gameObject.name = coord_text;

        transform.position = snapPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Vector2Int[] directions = {
        new Vector2Int(0, 1),
        new Vector2Int(1, 1)
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlock();
        ColorStartEnd();
        ExploreNeighbours();
    }

    void LoadBlock() {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Overlapping block " + waypoint);
            }
            else {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    private void ColorStartEnd() {
        startWaypoint.SetTopColor(Color.green);
        
    }

    private void ExploreNeighbours() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

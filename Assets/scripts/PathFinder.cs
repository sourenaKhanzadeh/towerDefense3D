using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
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
        endWaypoint.SetTopColor(Color.yellow);
    }

    private void ExploreNeighbours() {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int exploreCoord = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[exploreCoord].SetTopColor(Color.blue);
            }
            catch {
                // do nothing
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

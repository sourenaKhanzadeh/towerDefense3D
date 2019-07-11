using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    private Queue<Waypoint> queue = new Queue<Waypoint>();
    private bool isRunning = true;
    private Waypoint searchCenter;

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
        // ExploreNeighbours();
        PathFind();
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
    private void PathFind() {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning) {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print("Searching from: " + searchCenter);
            HaltIfEndFound();
            ExploreNeighbours();
        }
    }
    private void HaltIfEndFound() {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours() {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int exploreCoord = searchCenter.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(exploreCoord);
            }
            catch {
                // do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinate) {
        Waypoint neighbour = grid[neighbourCoordinate];
        if (!neighbour.isExplored || !queue.Contains(neighbour)) {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            print("Queuing " + neighbour);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

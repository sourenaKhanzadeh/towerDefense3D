using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;
    [SerializeField] float delay = 1f;


    [SerializeField] Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, transform.position.y, 0f);
        StartCoroutine(PrintAllWaypoints());
    }

    IEnumerator PrintAllWaypoints() {
        foreach (Block waypoint in path)
        {
            transform.position = waypoint.transform.position + offset;
            yield return new WaitForSeconds(delay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

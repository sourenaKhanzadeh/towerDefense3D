using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    private void FixedUpdate()
    {
        transform.LookAt(player.transform);
    }
}

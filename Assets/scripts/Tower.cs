using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(FindObjectOfType<robotAnimScript>().gameObject.transform);    
    }
}

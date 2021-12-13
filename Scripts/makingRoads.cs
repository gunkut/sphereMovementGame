using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makingRoads : MonoBehaviour
{
    public GameObject last_road;
    static Vector3 sphereDirection = Vector3.forward;
    int a;
    void Start()
    {
    }

    void Update()
    {
        
    }
    public void makingRoad()
    {
        if(sphereDirection==Vector3.forward)
        {
            a = Random.Range(0, 3);
            if (a == 0)
                sphereDirection = Vector3.forward;
            else if (a == 1)
                sphereDirection = Vector3.left;
            else
                sphereDirection = Vector3.right;          
        }

        else if(sphereDirection == Vector3.left)
        {
            a = Random.Range(0, 2);
            if (a == 0)
                sphereDirection = Vector3.forward;
            else
                sphereDirection = Vector3.left;
        }

        else if (sphereDirection == Vector3.right)
        {
            a = Random.Range(0, 2);
            if (a == 0)
                sphereDirection = Vector3.forward;
            else
                sphereDirection = Vector3.right;
        }

        last_road = Instantiate(last_road, last_road.transform.position + sphereDirection, last_road.transform.rotation);
    }
}

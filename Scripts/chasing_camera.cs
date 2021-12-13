using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasing_camera : MonoBehaviour
{
    public Transform following_sphere;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - following_sphere.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        if (sphereMovement.fall == true)
            return;

        transform.position = following_sphere.position + distance;
    }
}

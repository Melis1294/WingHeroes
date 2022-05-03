using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speed = 2000.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, Time.deltaTime * speed, Space.Self);
    }
}

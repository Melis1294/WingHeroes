using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 5.0f;
    private float xBound = 19.0f;

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(Vector3.right * Time.deltaTime * -speed);

        if (gameObject.name != "Background" && transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }
}

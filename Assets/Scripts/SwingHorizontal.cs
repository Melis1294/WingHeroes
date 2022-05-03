using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingHorizontal : MonoBehaviour
{
    private float speed = 1.5f;
    private float durationTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeSpeedDirection", durationTime, durationTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void ChangeSpeedDirection()
    {
        speed = -speed;
    }
}

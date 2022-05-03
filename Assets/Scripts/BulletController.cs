using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 9.0f;
    private float xBound = 15.5f;
    private float upperBound = 16.2f;
    private float lowerBound = -2.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);

        if (transform.position.x > xBound || transform.position.y > upperBound || transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }            
        }            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}

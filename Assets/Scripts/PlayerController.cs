using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float upperBound = 14.5f;
    private float hBound = 13.15f;
    private float thrust = 200f;
    private bool gameOver;
    private Rigidbody playerRb;    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ManageBounds();
    }

    void MovePlayer()
    {        
        // player dead cannot move
        if (!gameOver)
        {
            // Move player left and right, up and down
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if (horizontalInput > 0)
                transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime, Space.Self);
            else
                transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime, Space.World);
            transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.forward * verticalInput * speed * 10 * Time.deltaTime, Space.Self);
        }
    }

    void ManageBounds()
    {
        if (transform.position.y > upperBound)
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);

        if (transform.position.x < -hBound)
            transform.position = new Vector3(-hBound, transform.position.y, transform.position.z);

        else if (transform.position.x > hBound / 2)
            transform.position = new Vector3(hBound / 2, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var deadlyCollision = collision.gameObject.CompareTag("Ground") 
            || collision.gameObject.CompareTag("Enemy") 
            || collision.gameObject.CompareTag("EnemyBullet");
        if (deadlyCollision && !gameOver)
        {
            gameOver = true;            
            playerRb.useGravity = true;
            playerRb.constraints = RigidbodyConstraints.None;
            playerRb.AddForce(new Vector3(1, 1, 0) * thrust);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}

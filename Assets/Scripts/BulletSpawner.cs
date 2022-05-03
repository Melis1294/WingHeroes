using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        } 
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reload Level
            SceneManager.LoadScene(0);
        }
    }
}

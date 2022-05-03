using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    private float startDelay = 3.0f;
    private float repeatRateMin = 0.5f;
    private float repeatRateMax = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", startDelay, Random.Range(repeatRateMin, repeatRateMax));
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}

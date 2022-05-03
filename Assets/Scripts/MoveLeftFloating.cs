using UnityEngine;

public class MoveLeftFloating : MonoBehaviour
{
    private float speed = 2.0f;
    private float xBound = 24.5f;
    // Floating variables
    public float frequency = 1f;
    float tempPosY;
    float tempPosX;
    // Start is called before the first frame update
    void Start()
    {
        tempPosY = transform.position.y;
        tempPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Float up/down with a Sin()
        float amplitude = Random.Range(1.0f, 3.0f);
        tempPosY += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude * Time.deltaTime;
        tempPosX += -speed * Time.deltaTime;
        transform.position = new Vector3(tempPosX, tempPosY, transform.position.z);

        if (gameObject.name != "Background" && transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
    }

}

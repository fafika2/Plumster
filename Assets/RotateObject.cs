using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Public variable to control the rotation speed
    public float rotationSpeed = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the Z axis at the specified speed, making it framerate independent
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 velocity;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = new Vector3(speed, 0f, 0f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + velocity * Time.deltaTime);

        // Check if the ball hits the right wall (x > 2)
        if (transform.position.x > 2f)
        {
            Vector3 normal = Vector3.left; // Wall normal pointing left
            ReflectVelocity(normal);
            PreventStickingToWall();
        }

        // Check if the ball hits the left wall (x < -6)
        if (transform.position.x < -6f)
        {
            Vector3 normal = Vector3.right; // Wall normal pointing right
            ReflectVelocity(normal);
            PreventStickingToWall();
        }
    }
        
    
        void ReflectVelocity(Vector3 normal)
        {
            float dot = Vector3.Dot(velocity, normal);
            velocity = velocity - 2 * dot * normal;
}

void PreventStickingToWall()
{
    Vector3 newPos = transform.position;
    if (transform.position.x > 2f)
    {
        newPos.x = 2f;
    }
    if (transform.position.x < -6f)
    {
        newPos.x = -6f;
    }
    transform.position = newPos;
    
}
}

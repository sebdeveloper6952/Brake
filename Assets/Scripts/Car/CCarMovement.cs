using UnityEngine;
using System.Collections;

public class CCarMovement : MonoBehaviour
{
    //public float accelForce;
    //public float brakeForce;

    private float accelForce;
    private float brakeForce;

    private float xMove = 0.64f;
    private float yMove = 0.32f;
    private float inputData;
    private Rigidbody2D rb;
    private Vector2 force;
    private bool braking;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(xMove, yMove);
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*braking = Input.touchCount > 0; // this is to brake touching the screen
        braking = Input.GetKey(KeyCode.Space); // this is to brake pressing space bar */
        braking = Input.acceleration.x < -0.1f;
        inputData = Input.acceleration.x;
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(braking && rb.velocity.x > 0f)
        {
            inputData -= 4f;
            rb.AddForce(force * inputData);
        }
        else if(!braking && rb.velocity.magnitude <2f)
        {
            inputData += 2f;
            rb.AddForce(force * inputData);
        }
    }
}

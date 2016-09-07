using UnityEngine;
using System.Collections;

public class CCarMovement : MonoBehaviour
{
    public static CCarMovement instance;

    private float xMove = 0.64f;
    private float yMove = 0.32f;
    private float accelX; // accelerometer x coordinate, used to brake
    private float accelY; // accelerometer y coordinate, used to turn
    public Rigidbody2D rb;
    private Vector2 force;
    private bool braking;

	// Use this for initialization
	void Start ()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        force = new Vector2(xMove, yMove);
	}
	
	// Update is called once per frame
	void Update ()
    {
        braking = Input.acceleration.x < -0.1f;
        accelX = Input.acceleration.x;
        accelY = Input.acceleration.y;
        if (!braking)
        {
            Turn();
        }
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(braking && rb.velocity.x > 0f)
        {
            accelX -= 4f;
            rb.AddForce(force * accelX);
        }
        else if(!braking && rb.velocity.magnitude <2f)
        {
            accelX += 2f;
            rb.AddForce(force * accelX);
        }
    }

    private void Turn()
    {
        if(accelY > -0.3f)
        {
            // turn left
            transform.Translate(new Vector3(0f, Time.deltaTime, 0f));
        }
        if(accelY < -0.7f)
        {
            // turn right
            transform.Translate(new Vector3(0f, -Time.deltaTime * 1.5f, 0f));
        }
    }
}

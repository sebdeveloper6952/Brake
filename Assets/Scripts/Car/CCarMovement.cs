using UnityEngine;
using System.Collections;

public class CCarMovement : MonoBehaviour
{
    //public float accelForce;
    //public float brakeForce; // maybe adjust later, as a multiplier to both accel and braking forces

    private float xMove = 0.64f;
    private float yMove = 0.32f;
    private float accelX; // accelerometer x coordinate, used to brake
    private float accelY; // accelerometer y coordinate, used to turn
    private Rigidbody2D rb;
    private Vector2 force;
    private bool braking;
    //private bool leftLane;

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
        accelX = Input.acceleration.x;
        accelY = Input.acceleration.y;
	}

    private void FixedUpdate()
    {
        Move();
        ChangeLanes();
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

    private void ChangeLanes()
    {
        if(accelY > -0.3f)
        {
            transform.Translate(new Vector3(Time.deltaTime, Time.deltaTime * 1.5f, 0f));
        }
        if(accelY < -0.7f)
        {
            transform.Translate(new Vector3(Time.deltaTime, -Time.deltaTime, 0f));
        }
        //if(accelY < -0.3f && accelY > -0.7f)
        //{
        //}
        //else if(leftLane && accelY <= -0.7f)
        //{
        //    // change to the right lane
        //    leftLane = !leftLane;
        //}
        //else if(!leftLane && accelY >= -0.3f)
        //{
        //    // change to the right lane
        //    leftLane = !leftLane;
        //}
    }
}

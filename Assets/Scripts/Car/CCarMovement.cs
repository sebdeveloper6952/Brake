using UnityEngine;
using System.Collections;

public class CCarMovement : MonoBehaviour
{
    public static CCarMovement instance;

    private float xMove;
    private float yMove;
    private float accelX; // accelerometer x coordinate, used to brake
    private float accelY; // accelerometer y coordinate, used to turn
    public Rigidbody2D rb;
    private Vector2 force;
    private bool braking;


    // called before start
    void Awake()
    {
        instance = this;
    }
	// Use this for initialization
	void Start ()
    {
        xMove = 0.64f;
        yMove = 0.3f;
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

    // called every physics tick
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
        if (accelY > -0.5f && transform.position.y < CTileManager.maxL)
        {
            // turn left
            transform.Translate(new Vector3(0f, Time.deltaTime, 0f));
        }
        else if (accelY < -0.7f && transform.position.y > CTileManager.maxR)
        {
            // turn right
            transform.Translate(new Vector3(0f, -Time.deltaTime * 1.5f, 0f));
        }
    }
}

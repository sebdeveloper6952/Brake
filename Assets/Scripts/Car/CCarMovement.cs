using UnityEngine;
using System.Collections;

public class CCarMovement : MonoBehaviour
{
    public static CCarMovement instance;
    public float distanceCovered;
    public float fuelLevel;

    private float xMove;
    private float yMove;
    private float accelX; // accelerometer x coordinate, used to brake
    private float accelY; // accelerometer y coordinate, used to turn
    private float maxSpeed; // speed of the car, this can increase up to maxFinalSpeed
    public Rigidbody2D rb;
    private Vector2 force;
    private bool braking;
    private const float maxFinalSpeed = 4f; // this is the absolute maximum speed
    private const float maxFuel = 100f;
    private const float minFuel = 0f;


    // called before start
    void Awake()
    {
        instance = this;
    }
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        xMove = 0.64f;
        yMove = 0.3f;
        maxSpeed = 2f;
        distanceCovered = 0f;
        fuelLevel = maxFuel;
        force = new Vector2(xMove, yMove);
        StartCoroutine(IncreaseCarSpeed());
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
        Distance();
        Fuel();
    }

    // called every physics tick
    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Moves the car, and brakes the car.
    /// </summary>
    private void Move()
    {
        if(braking && rb.velocity.x > 0f)
        {
            accelX -= 4f;
            rb.AddForce(force * accelX);
        }
        else if(!braking && rb.velocity.magnitude < maxSpeed)
        {
            accelX += 2f;
            rb.AddForce(force * accelX);
        }
    }

    private IEnumerator IncreaseCarSpeed()
    {
        while (maxSpeed < maxFinalSpeed)
        {
            yield return new WaitForSeconds(30f);
            maxSpeed += 0.5f;
        }
    }

    /// <summary>
    /// Turns the car according to accelrator input. Makes sure the car stays in it turning range.
    /// </summary>
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
            transform.Translate(new Vector3(0f, -Time.deltaTime * 2f, 0f));
        }
    }

    /// <summary>
    /// Calculates the distance the car has traveled.
    /// </summary>
    private void Distance()
    {
        if(rb.velocity.magnitude > 0.1f)
        {
            distanceCovered += rb.velocity.magnitude / 25f;
        }
    }

    /// <summary>
    /// Calculates fuel usage.
    /// </summary>
    private void Fuel()
    {
        if(rb.velocity.magnitude > 0.1f)
        {
            fuelLevel -= rb.velocity.magnitude / 50.0f;
        }
    }
}

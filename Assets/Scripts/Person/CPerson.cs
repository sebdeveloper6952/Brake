using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPerson : MonoBehaviour
{
    public GameObject bloodSplat;

    private float xMove;
    private float yMove;
    private float direction;
    private float speed;


    private void Start()
    {
        xMove = 0.48f;
        yMove = -0.22f;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector2(xMove, yMove) * direction * speed * Time.deltaTime);
    }

    /// <summary>
    /// Sets the moving direction of this person.
    /// </summary>
    /// <param name="dir"></param>
    public void SetDirectionAndSpeed(float dir)
    {
        this.direction = dir;
        this.speed = Random.Range(0.5f, 1.5f);
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void RunnedOver()
    {
        Instantiate(bloodSplat, transform.position, transform.rotation);
        CPeopleManager.peopleKilled++;
        gameObject.SetActive(false);
    }
}

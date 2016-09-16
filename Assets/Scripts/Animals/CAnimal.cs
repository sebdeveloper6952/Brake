using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimal : MonoBehaviour
{
    /* This is the base class that controls the behaviour of the animals. */
    public GameObject bloodSplat;
    public Sprite imgHaciaArriba;

    private Sprite imgHaciaAbajo;
    private SpriteRenderer sr;
    private float xMove;
    private float yMove;
    private float direction;
    private float speed;
    private float lifeTime;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        imgHaciaAbajo = sr.sprite;
    }

    private void Start()
    {
        xMove = 0.48f;
        yMove = -0.22f;
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Moves this animal according to its direction and speed.
    /// </summary>
    private void Move()
    {
        transform.Translate(new Vector2(xMove, yMove) * direction * speed * Time.deltaTime);
    }


    /// <summary>
    /// Sets the moving direction, speed, and lifeTime of this animal.
    /// </summary>
    /// <param name="dir"></param>
    public void SetDirectionAndSpeed(float dir)
    {
        if (dir == -1f) // mostrar la imagen correcta de acuerdo a la direccion del animal
            sr.sprite = imgHaciaArriba;
        else
            sr.sprite = imgHaciaAbajo;
        this.direction = dir;
        this.speed = Random.Range(0.5f, 2.5f);
        if (this.speed > 2f)
            lifeTime = 3f;
        else if (this.speed > 1f)
            lifeTime = 4f;
        else
            lifeTime = 5f;
    }

    /// <summary>
    /// Waits for lifeTime seconds and disables this animal.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Instantiates blood, increases amount of animals killed, and disables this animal
    /// </summary>
    private void RunnedOver()
    {
        Instantiate(bloodSplat, transform.position, transform.rotation);
        CAnimalsManager.animalsKilled++;
        gameObject.SetActive(false);
    }
}

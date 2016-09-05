using UnityEngine;
using System.Collections;

public class CCamera : MonoBehaviour
{
    public GameObject car;
	// Use this for initialization
	void Start ()
    {
	
	}
	
    void LateUpdate()
    {
        transform.position = new Vector3(car.transform.position.x, car.transform.position.y, -10f);
    }
}

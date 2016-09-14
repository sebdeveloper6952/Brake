using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFuelPickup : MonoBehaviour
{
    private void RefillFuelTank()
    {
        CCarMovement.instance.fuelLevel = 100f;
        gameObject.SetActive(false);
    }
}

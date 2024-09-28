using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GiftValidator : MonoBehaviour
{
    private bool danger;
    public GameObject smokeVFX;
    
    public Color houseID; //<----- Identifier for house

    private void Start()
    {
        InvokeRepeating("UpdateDangerStatus", 3, 6);
    }

    private void UpdateDangerStatus()
    {
        danger = !danger;
        smokeVFX.SetActive(danger);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PostOffice")
        {
            Validating(other.gameObject);
        }
        Debug.Log("goal!");
        Destroy(other.gameObject);
    }

    private void Validating(GameObject deliveredGift)
    {
        if (deliveredGift.GetComponent<GiftInfoHolder>().giftID == houseID && !danger)
        {
            Debug.Log("Gift Delivered!");
            PointManager.currentPoints += 10;
        }
        else if (danger)
        {
            Debug.Log("Gift got burned!");
            PointManager.currentPoints -= 5;
        }
        else
        {
            Debug.Log("Wrong House!");
        }
    }
}

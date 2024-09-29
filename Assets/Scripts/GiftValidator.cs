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

    public GameObject GiftSuccess;
    public GameObject GiftBurned;
    public GameObject GiftWrong;
    
    
    public Color houseID; //<----- Identifier for house

    private void Start()
    {
        InvokeRepeating("UpdateDangerStatus", 3, Random.Range(0, 10));
    }

    private void UpdateDangerStatus()
    {
        danger = !danger;
        smokeVFX.SetActive(danger);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gift")
        {
            Validating(other.gameObject);
            Destroy(other.gameObject);
        }
        Debug.Log("goal!");
    }

    private void Validating(GameObject deliveredGift)
    {
        if (deliveredGift.GetComponent<GiftInfoHolder>().giftID == houseID && !danger)
        {
            GiftSuccess.SetActive(true);
            Debug.Log("Gift Delivered!");
            PointManager.currentPoints += 10;
        }
        else if (danger)
        {
            GiftBurned.SetActive(true);
            Debug.Log("Gift got burned!");
            PointManager.currentPoints -= 5;
        }
        else
        {
            GiftWrong.SetActive(true);
            Debug.Log("Wrong House!");
        }
    }
}

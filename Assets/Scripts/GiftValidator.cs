using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiftValidator : MonoBehaviour
{
    private bool danger;
    public Color houseID; //<----- Identifier for house
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PostOffice")
        {
            Validating(other.gameObject);
        }
        Destroy(other);
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

using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class GiftInfoHolder : MonoBehaviour
{
    public Color giftID; //<----- Identifier for gift
    private bool colored_the_gift = false;

    private void Start()
    {
        {
            if (!colored_the_gift)
            {
                GameObject gift = this.gameObject;

                if (gift != null)
                {
                    Color giftColor = HouseColoring.colors[Random.Range(0, HouseColoring.colors.Length)];
                    GiftInfoHolder giftInfoHolder = this;

                    // Update gift ID
                    giftInfoHolder.giftID = giftColor;

                    // Get the Renderer component
                    Renderer renderer = gift.GetComponent<Renderer>();

                    if (renderer != null)
                    {
                        // Access the material of the Renderer
                        Material
                            mat = renderer.material; // Use .sharedMaterial if you want to change it for all instances

                        if (mat != null)
                        {
                            mat.color = giftColor; // Change the color of the material
                            Debug.Log($"Changed Albedo color of Gift_01 to {giftColor}");
                            colored_the_gift = true;
                        }
                        else
                        {
                            Debug.LogWarning("Material not found on the renderer.");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Renderer not found on Gift_01.");
                    }
                }
                else
                {
                    Debug.LogWarning("Gift_01 not found in the scene.");
                }
            }
        }
    }
}

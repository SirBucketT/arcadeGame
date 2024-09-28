using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System.Linq;

public class GameWorld : MonoBehaviour
{

    private Color[] colors;    // Array to store 30 distinct colors

    void Start()
    {
        // Randomly select between prefab1 and prefab2 with 50% chance
        //if (Random.Range(0, 2) == 0)

        // Define 30 distinct colors
        colors = new Color[]
        {
            Color.red, Color.green, Color.blue, Color.yellow, Color.cyan, Color.magenta,
            new Color(1f, 0.5f, 0f), new Color(0.5f, 0f, 1f), new Color(0f, 0.5f, 1f),
            new Color(1f, 0.2f, 0.6f), new Color(0.2f, 0.8f, 0.2f), new Color(0.8f, 0.8f, 0.2f),
            new Color(0.6f, 0.1f, 0.6f), new Color(0.3f, 0.7f, 0.9f), new Color(0.7f, 0.3f, 0.1f),
            new Color(0.1f, 0.7f, 0.3f), new Color(0.9f, 0.6f, 0.4f), new Color(0.4f, 0.9f, 0.6f),
            new Color(0.8f, 0.4f, 0.8f), new Color(0.6f, 0.8f, 0.4f), new Color(0.2f, 0.3f, 0.9f),
            new Color(0.9f, 0.3f, 0.2f), new Color(0.3f, 0.9f, 0.7f), new Color(0.9f, 0.7f, 0.3f),
            new Color(0.7f, 0.9f, 0.2f), new Color(0.2f, 0.9f, 0.5f), new Color(0.5f, 0.2f, 0.9f),
            new Color(0.4f, 0.2f, 0.7f), new Color(0.7f, 0.4f, 0.2f), new Color(0.2f, 0.4f, 0.7f)
        };

        // Instantiate the prefab
        //GameObject instance = Instantiate(selectedPrefab, Vector3.zero, Quaternion.identity);

          // Get all active GameObjects in the scene
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();


        // Create a list to hold filtered objects
        List<GameObject> filteredObjects = new List<GameObject>();


                // Loop through all objects and check if their name starts with "suburban-house-"
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.name.StartsWith("suburban-house-"))
            {
                filteredObjects.Add(obj);
                //Debug.Log("Found GameObject: " + obj.name);
            }
        }


        // Example: Print the names of the found objects
        foreach (GameObject obj in filteredObjects) {
                    // Apply random color to all child entities
            ApplyRandomAlbedoColorToChildren(obj);
        }


    }

    void ApplyRandomAlbedoColorToChildren(GameObject parent)
    {
        // Get all child objects (and parent itself) that have a Renderer component
        Renderer[] renderers = parent.GetComponentsInChildren<Renderer>();

        // Choose a random color from the array of distinct colors
        Color randomColor = colors[Random.Range(0, colors.Length)];

        foreach (Renderer renderer in renderers)
        {
            // Iterate through all materials on the object
            foreach (Material mat in renderer.materials)
            {
                Debug.Log(mat.name);
                // Optional: if you want to target a specific material by name (e.g., "M_City")
                if (mat.name.Contains("main-color-palette_mat"))
                {

                    // Change the Albedo (diffuse color) of the material
                    mat.SetColor("_Color", randomColor);

                    Debug.Log($"Changed Albedo color of {mat.name} to {randomColor}");
                }
            }
        }
    }
}
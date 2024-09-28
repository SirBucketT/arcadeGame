using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameWorld : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    GameObject selectedPrefab;

    private Color[] colors;    // Array to store 30 distinct colors
    public string materialName = "M_City"; // Name of the material to change (optional)

    void Start()
    {
        // Randomly select between prefab1 and prefab2 with 50% chance
        if (Random.Range(0, 2) == 0)
        {
            selectedPrefab = prefab1; // Choose prefab1
        }
        else
        {
            selectedPrefab = prefab2; // Choose prefab2
        }

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
        GameObject instance = Instantiate(selectedPrefab, Vector3.zero, Quaternion.identity);

        // Apply random color to all child entities
        ApplyRandomAlbedoColorToChildren(instance);
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
                // Optional: if you want to target a specific material by name (e.g., "M_City")
                if (string.IsNullOrEmpty(materialName) || mat.name.Contains(materialName))
                {

                    // Change the Albedo (diffuse color) of the material
                    mat.SetColor("_Color", randomColor);

                    Debug.Log($"Changed Albedo color of {mat.name} to {randomColor}");
                }
            }
        }
    }
}
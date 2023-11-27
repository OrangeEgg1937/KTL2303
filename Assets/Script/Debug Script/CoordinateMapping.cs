using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateMapping : MonoBehaviour
{
    // The color of the coordinate text
    [SerializeField] Color coordinateColor = Color.black;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    // initial the variables when awake
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCoordinates();
        UpdateObjectName();
    }

    // Display the coordinate text
    private void DisplayCoordinates()
    {
        // Get the coordinates of x-axis
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x);

        // Get the coordinates of z-axis
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z);

        // Display the coordinates
        // label.text = "(" + coordinates.x + "," + coordinates.y + ")";
    }

    // Update the object name in the editor
    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}

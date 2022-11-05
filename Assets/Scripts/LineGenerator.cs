using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    // Variable declarations
    public int lengthOfLineRenderer = 20;
    public float xScale = 1.0f;
    public float heightScale = 1.0f;
    public float noiseXScale = 1.0f;
    [HideInInspector] public LineRenderer lineRenderer;

    public void GenerateLine()
    {
        // Create new lineRenderer on gameObject, adding a default sprite material and set it's length.
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // Create a series of points sampling Perlin noise.

        var linePoints = new Vector3[lengthOfLineRenderer];
        float height = 0f;
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            height = (heightScale * Mathf.PerlinNoise(noiseXScale * i / lengthOfLineRenderer, 0.0f)) - heightScale / 2;

            linePoints[i] = new Vector3(i * xScale, height, 0.0f);
        }
        lineRenderer.SetPositions(linePoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

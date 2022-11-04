using UnityEngine;
using System.Collections;

public class LineAnimator : MonoBehaviour
{
    [SerializeField] private float animationDuration = 5f;

    private LineRenderer lineRenderer;
    private Vector3[] linePoints;
    private Vector3 lineStart;
    private int pointsCount;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Store a copy of lineRenderer's points in linePoints array
        pointsCount = lineRenderer.positionCount;
        linePoints = new Vector3[pointsCount];
        lineStart = lineRenderer.GetPosition(0);
        for (int i = 0; i < pointsCount; i++)
        {
            linePoints[i] = lineRenderer.GetPosition(i);
            lineRenderer.SetPosition(i, lineStart);
        }

        // Start CoRoutine Method
        StartCoroutine(AnimateLine());

        // Rotate Line Around Up By 180 pivoting on starting position
        gameObject.transform.RotateAround(lineStart, Vector3.up, 180);

    }

    private IEnumerator AnimateLine()
    {
        float segmentDuration = animationDuration / pointsCount;

        for (int i = 0; i < pointsCount - 1; i++)
        {
            float startTime = Time.time;

            Vector3 startPosition = linePoints[i];
            Vector3 endPosition = linePoints[i + 1];

            Vector3 pos = startPosition;
            while (pos != endPosition)
            {
                float t = (Time.time - startTime) / segmentDuration;
                pos = Vector3.Lerp(startPosition, endPosition, t);

                // animate all other points except point at index i
                for (int j = i + 1; j < pointsCount; j++)
                    lineRenderer.SetPosition(j, pos);

                yield return null;
            }
        }


    }
}
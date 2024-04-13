using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Boundaries
    {
        public static Dictionary<string, float> FindBoundaries(CircleCollider2D collider)
        {
            Camera mainCamera = Camera.main;

            float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + collider.radius;
            float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - collider.radius;
            float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + collider.radius;
            float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - collider.radius;

            Dictionary<string, float> boundaries = new Dictionary<string, float>
            {
                {"minX", minX},
                {"maxX", maxX},
                {"minY", minY},
                {"maxY", maxY}
            };

            return boundaries;
        }
        public static Vector2 RandomCoordInBound(string coordType, CircleCollider2D collider)
        {
            Camera mainCamera = Camera.main;

            float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + collider.radius;
            float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - collider.radius;
            float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + collider.radius;
            float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - collider.radius;

            Vector2 coordHorizontal = new Vector2(UnityEngine.Random.Range(minX, maxX), maxY);

            Vector2 coord = new Vector2(UnityEngine.Random.Range(minY, maxY), UnityEngine.Random.Range(minX, maxX));

            Dictionary<string, Vector2> dict = new Dictionary<string, Vector2>{
                {"coordHorizontal", coordHorizontal},
                {"cord", coord},
            };
            Debug.Log($"{dict[coordType]}");

            return dict[coordType];
        }
    }
}
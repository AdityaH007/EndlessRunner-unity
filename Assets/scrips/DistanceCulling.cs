using UnityEngine;

public class DistanceCulling : MonoBehaviour
{
    public float renderDistance = 50f;

    void Update()
    {
        // Get all objects with a renderer component in the scene
        Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();

        // Get the camera's position
        Vector3 cameraPosition = transform.position;

        foreach (Renderer renderer in renderers)
        {
            // Check the distance between the camera and each object
            float distance = Vector3.Distance(renderer.bounds.center, cameraPosition);

            // Disable rendering for objects beyond the specified distance
            renderer.enabled = distance <= renderDistance;
        }
    }
}

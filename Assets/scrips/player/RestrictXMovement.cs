using UnityEngine;

public class RestrictXMovement : MonoBehaviour
{
    public float restrictedXPosition = 0f;

    void LateUpdate()
    {
        // Set the position to restrict movement along the x-axis
        transform.position = new Vector3(restrictedXPosition, transform.position.y, transform.position.z);
    }
}

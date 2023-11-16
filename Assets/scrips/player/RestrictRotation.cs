using UnityEngine;

public class RestrictRotation : MonoBehaviour
{
    void LateUpdate()
    {
       
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _target;

    void LateUdpate()
    {
        transform.position = _target.position;
    }
}

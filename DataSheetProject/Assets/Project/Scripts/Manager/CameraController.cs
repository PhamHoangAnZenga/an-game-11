using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _target;
    public void Init(Transform target)
    {
        _target = target;
    }
    
    void LateUdpate()
    {
        transform.position = _target.position;
    }
}

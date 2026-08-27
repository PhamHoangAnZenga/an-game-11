using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _moveSpeed;

    Vector3 _moveDirection;
    Transform _target;

    void Update()
    {
        _moveDirection = _target.position - transform.position;
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime);        
    }
}

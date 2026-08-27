using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Joystick _joystick;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _moveSpeed;

    Vector3 _moveDirection;

    void Init(Joystick input, float moveSpeed)
    {
        _joystick = input;
        _moveSpeed = moveSpeed;
    }

    //TODO: có thể thêm state machine để quản lý
    void Update()
    {
        _moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
    }

    void FixedUpdate()
    {
        if (_moveDirection.magnitude > 0.01f)
        {
            _rigidbody.MovePosition(transform.position + _moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime);
        }
    }
}

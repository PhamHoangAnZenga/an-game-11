using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _moveSpeed;

    Vector3 _moveDirection;
    Transform _target;
    GameController _gameController;

    public void Init(Transform target, GameController gameController)
    {
        _target = target;
        _gameController = gameController;
    }

    public void OnGameOver()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        _moveDirection = _target.position - transform.position;
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Equals(collision.gameObject, _target.gameObject))
        {
            _gameController.LoseGame();
        }
    }
}

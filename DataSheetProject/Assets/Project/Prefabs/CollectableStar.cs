using UnityEngine;

public class CollectableStar : MonoBehaviour
{
    [SerializeField] GameController _gameController;

    void OnTriggerEnter(Collider other)
    {
        _gameController.CollectStar();
    }
}

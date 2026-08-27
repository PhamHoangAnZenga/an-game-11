using UnityEngine;

public class CollectableStar : MonoBehaviour
{
    GameController _gameController;

    public void Init(GameController gameController)
    {
        _gameController = gameController;
    }

    void OnTriggerEnter(Collider other)
    {
        _gameController.CollectStar();
    }
}

using UnityEngine;

public class CollectableStar : MonoBehaviour
{
    GameController _gameController;

    public void Init(GameController gameController)
    {
        _gameController = gameController;
    }
    
    public void OnGameOver()
    {        
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        _gameController.CollectStar(this);
        Destroy(gameObject);
    }

}

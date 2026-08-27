using UnityEngine;

public class GameLoading : MonoBehaviour
{
    Player _playerPrefab;
    Enemy _enemyPrefab;
    CollectableStar _starPrefab;
    TextAsset _text;

    void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        _playerPrefab = Resources.Load<Player>("Player");
        _enemyPrefab = Resources.Load<Enemy>("Enemy");
        _starPrefab = Resources.Load<CollectableStar>("Star");

        _text = Resources.Load<TextAsset>("Data/leveldata");
    }


}

using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] CameraController _cameraController;
    [SerializeField] GameLoading _gameLoader;
    [SerializeField] Joystick _joystick;
    [SerializeField] Player _player;

    void Awake()
    {
        _gameLoader.LoadData();
    }

    void Start()
    {
        StartLevel(0);
        _cameraController.Init(_player.transform);
    }

    void StartLevel(int level)
    {
        int id = level % _gameLoader.LevelDTOs.Count;

        // _player = Instantiate(_gameLoader.GetPlayerPrefab(), Vector3.up, Quaternion.identity);

        foreach (MonsterDTO monster in _gameLoader.LevelDTOs[id].Monster)
        {
            Enemy enemy = Instantiate(_gameLoader.GetEnemyPrefabs(monster.Name), new Vector3(monster.SpawnX, 1, monster.SpawnY), Quaternion.identity);
            enemy.Init(_player.transform);
        }

        foreach (ObstacleDTO obstacle in _gameLoader.LevelDTOs[id].Obstacle)
        {
            Instantiate(_gameLoader.GetObstaclePrefabs(obstacle.Name), new Vector3(obstacle.SpawnX, 1, obstacle.SpawnY), Quaternion.identity);
        }

        foreach (StarDTO star in _gameLoader.LevelDTOs[id].Star)
        {
            CollectableStar collectableStar = Instantiate(_gameLoader.GetStarPrefabs(), new Vector3(star.SpawnX, 1, star.SpawnY), Quaternion.identity);
            collectableStar.Init(this);
        }
    }

    public void CollectStar()
    {
    }
}

using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Action OnEndGame;

    [SerializeField] CameraController _cameraController;
    [SerializeField] GameLoading _gameLoader;    
    [SerializeField] Joystick _joystick;
    [SerializeField] Player _player;
    [SerializeField] ResultMenuController _resultMenu;

    int _starCollected = 0;
    int _currentLevel = 0;

    void Awake()
    {
        _gameLoader.LoadData();
        _resultMenu.CloseMenu();
    }

    void Start()
    {
        StartLevel(0);
    }

    public void NextButton()
    {
        _currentLevel += 1;
        StartLevel(_currentLevel);

        _resultMenu.CloseMenu();
    }

    public void ResetButton()
    {
        StartLevel(_currentLevel);

        _resultMenu.CloseMenu();
    }

    public void CollectStar(CollectableStar star)
    {
        _starCollected += 1;
        OnEndGame -= star.OnGameOver;
        if (_starCollected >= 3)
        {
            Time.timeScale = 0f;    
            _resultMenu.OpenWinMenu();
        }
    }
    
    public void LoseGame()
    {
        Time.timeScale = 0f;
        _resultMenu.OpenLoseMenu();        
    }

    void StartLevel(int level)
    {
        OnEndGame?.Invoke();
        OnEndGame = null;
        _starCollected = 0;

        // _player = Instantiate(_gameLoader.GetPlayerPrefab(), Vector3.up, Quaternion.identity);
        _cameraController.Init(_player.transform);
        _player.transform.position = Vector3.up;

        int id = level % _gameLoader.LevelDTOs.Count;

        foreach (MonsterDTO monster in _gameLoader.LevelDTOs[id].Monster)
        {
            Enemy enemy = Instantiate(_gameLoader.GetEnemyPrefabs(monster.Name), new Vector3(monster.SpawnX, 1, monster.SpawnY), Quaternion.identity);
            enemy.Init(_player.transform, this);
            OnEndGame += enemy.OnGameOver;
        }

        foreach (ObstacleDTO obstacle in _gameLoader.LevelDTOs[id].Obstacle)
        {
            GameObject obj = Instantiate(_gameLoader.GetObstaclePrefabs(obstacle.Name), new Vector3(obstacle.SpawnX, 1, obstacle.SpawnY), Quaternion.identity);
            OnEndGame += () => Destroy(obj);
        }

        foreach (StarDTO star in _gameLoader.LevelDTOs[id].Star)
        {
            CollectableStar collectableStar = Instantiate(_gameLoader.GetStarPrefabs(), new Vector3(star.SpawnX, 1, star.SpawnY), Quaternion.identity);
            collectableStar.Init(this);
            OnEndGame += collectableStar.OnGameOver;
        }
        
        Time.timeScale = 1f;
    }
}

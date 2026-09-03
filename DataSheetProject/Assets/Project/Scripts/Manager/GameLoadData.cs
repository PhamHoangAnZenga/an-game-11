using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLoadData : MonoBehaviour
{
    public List<LevelDTO> LevelDTOs;
    public List<LevelDTO> InputLevelDTOs;
    GameData gameData = new GameData();

    Player _playerPrefab;
    Enemy _enemyPrefab;
    GameObject _obstaclePrefab;
    CollectableStar _starPrefab;

    public Player GetPlayerPrefab()
    {
        return _playerPrefab;
    }

    public Enemy GetEnemyPrefabs(string name)
    {
        return _enemyPrefab;
    }

    public GameObject GetObstaclePrefabs(string name)
    {
        return _obstaclePrefab;
    }

    public CollectableStar GetStarPrefabs()
    {
        return _starPrefab;
    }

    public void LoadData()
    {
        TextAsset textData = Resources.Load<TextAsset>("Data/LevelData");
        if (textData is not null)
        {
            gameData = JsonUtility.FromJson<GameData>(textData.text);
            DataProcessing();
        }

        _playerPrefab = Resources.Load<Player>("Prefabs/Player");
        _enemyPrefab = Resources.Load<Enemy>("Prefabs/Enemy");
        _obstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacle");
        _starPrefab = Resources.Load<CollectableStar>("Prefabs/Star");
    }

    public void ExportData()
    {
        Deprocessing();
        string json = JsonUtility.ToJson(gameData, true);
        string savePath = "Data/LevelData.json";
        if (!Directory.Exists(Path.GetDirectoryName(savePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(savePath));
        }
        File.WriteAllText(savePath, json);
    }

    void DataProcessing()
    {
        LevelDTOs = new List<LevelDTO>();
        int id = 0;
        foreach (var data in gameData.LevelDatas)
        {
            if (id < data.Level)
            {
                id += 1;
                LevelDTOs.Add(new LevelDTO());
            }
            if (Enum.TryParse(data.Type, true, out DataType type))
            {
                switch (type)
                {
                    case DataType.Enemy: LevelDTOs[id - 1].Monster.Add(new MonsterDTO(data)); break;
                    case DataType.Obstacle: LevelDTOs[id - 1].Obstacle.Add(new ObstacleDTO(data)); break;
                    case DataType.Star: LevelDTOs[id - 1].Star.Add(new StarDTO(data)); break;
                }
            }
        }
    }

    void Deprocessing()
    {
        gameData.LevelDatas = new List<LevelData>();
        foreach (LevelDTO item in InputLevelDTOs)
        {
            foreach (MonsterDTO monster in item.Monster)
            {
                gameData.LevelDatas.Add(new LevelData(item.Level, DataType.Enemy, monster.Name, monster.SpawnX, monster.SpawnY));
            }
            foreach (ObstacleDTO obstacle in item.Obstacle)
            {
                gameData.LevelDatas.Add(new LevelData(item.Level, DataType.Obstacle, obstacle.Name, obstacle.SpawnX, obstacle.SpawnY));
            }
            foreach (StarDTO star in item.Star)
            {
                gameData.LevelDatas.Add(new LevelData(item.Level, DataType.Star, star.Name, star.SpawnX, star.SpawnY));
            }
        }
    }
}

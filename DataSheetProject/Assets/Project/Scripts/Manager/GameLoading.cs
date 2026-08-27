using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLoading : MonoBehaviour
{
    public List<LevelDTO> LevelDTOs;
    GameData gameData;

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
        TextAsset textData = Resources.Load<TextAsset>("Data/leveldata");
        if (textData is not null)
        {
            gameData = JsonUtility.FromJson<GameData>(textData.text);
            DataProcessing();
        }

        _playerPrefab = Resources.Load<Player>("Prefabs/Player");
        _enemyPrefab = Resources.Load<Enemy>("Prefabs/Enemy");
        _obstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacle");
        _starPrefab = Resources.Load<CollectableStar>("Prefabs/Star");

        Debug.Log(1);
        Debug.Log(_enemyPrefab.name);

    }

    public void ExportData()
    {
        Deprocessing();

        string json = JsonUtility.ToJson(gameData, true);
        string savePath = "Data/GameSavedData.json";
        File.WriteAllText(savePath, json);
    }

    void DataProcessing()
    {
        foreach (var item in gameData.LevelDatas)
        {

        }
    }
        
    void Deprocessing()
    {
        gameData.LevelDatas = new List<LevelData>();
        foreach(LevelDTO item in LevelDTOs)
        {
            foreach(MonsterDTO monster in item.Monster)
            {
                gameData.LevelDatas.Add(new LevelData(item.Level, DataType.Enemy, monster.Name, monster.SpawnX, monster.SpawnY) );
            }
        }
    }    
}

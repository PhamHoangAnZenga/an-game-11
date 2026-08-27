using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLoading : MonoBehaviour
{
    GameData gameData;
    
    Player _playerPrefab;
    Enemy _enemyPrefab;
    CollectableStar _starPrefab;

    List<LevelDTO> _levelDatas;
    
    void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        TextAsset textData = Resources.Load<TextAsset>("Data/leveldata");
        gameData = JsonUtility.FromJson<GameData>(textData.text);
        DataProcessing();

        _playerPrefab = Resources.Load<Player>("Prefabs/Player");
        _enemyPrefab = Resources.Load<Enemy>("Prefabs/Enemy");
        _starPrefab = Resources.Load<CollectableStar>("Prefabs/Star");
    }

    void DataProcessing()
    {
        foreach(var item in gameData.LevelDatas)
        {
            
        }
    }    

    public void ExportData()
    {
        string json = JsonUtility.ToJson(gameData, true);
        string savePath = "Data/GameSavedData.json";
        File.WriteAllText(savePath, json);
    }
}

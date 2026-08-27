using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelDTO : ScriptableObject
{
    public int Level;
    public List<MonsterDTO> Monster;
    public List<ObstacleDTO> Obstacle;
    public List<StarDTO> Star;

    public LevelDTO()
    {
        Monster = new List<MonsterDTO>();
        Obstacle = new List<ObstacleDTO>();
        Star = new List<StarDTO>();
    }
}

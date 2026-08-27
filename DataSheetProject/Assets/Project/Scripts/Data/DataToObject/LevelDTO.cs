using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelDTO : ScriptableObject
{
    public int Level;
    public List<MonsterDTO> Monster;
    public List<ObstacleDTO> Obstacle;
    public List<StarDTO> Star;
}

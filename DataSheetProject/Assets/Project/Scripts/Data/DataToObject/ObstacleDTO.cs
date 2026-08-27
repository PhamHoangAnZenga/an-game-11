[System.Serializable]
public class ObstacleDTO 
{
    public string Name;
    public float SpawnX;
    public float SpawnY;

    public ObstacleDTO(LevelData data)
    {
        Name = data.Name;
        SpawnX = data.SpawnPositionX;
        SpawnY = data.SpawnPositionY;
    }
}

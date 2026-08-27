public enum DataType
{
    Star,
    Enemy,
    Obstacle
}

[System.Serializable]
public class LevelData
{
    public int Level;
    public string Type;
    public string Name;
    public float SpawnPositionX;
    public float SpawnPositionY;

    public LevelData(int level, DataType type, string name, float spawnX, float spawnY)
    {
        Level = level;
        Type = type.ToString();
        Name = name;
        SpawnPositionX = spawnX;
        SpawnPositionY = spawnY;
    }
}

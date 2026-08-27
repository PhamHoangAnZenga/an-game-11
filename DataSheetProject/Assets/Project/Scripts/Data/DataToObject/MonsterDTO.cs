[System.Serializable]
public class MonsterDTO
{
    public string Name;
    public float SpawnX;
    public float SpawnY;

    public MonsterDTO(LevelData data)
    {
        Name = data.Name;
        SpawnX = data.SpawnPositionX;
        SpawnY = data.SpawnPositionY;
    }
}

[System.Serializable]
public class StarDTO
{
    public string Name;
    public float SpawnX;
    public float SpawnY;

    public StarDTO(LevelData data)
    {
        Name = data.Name;
        SpawnX = data.SpawnPositionX;
        SpawnY = data.SpawnPositionY;
    }
}

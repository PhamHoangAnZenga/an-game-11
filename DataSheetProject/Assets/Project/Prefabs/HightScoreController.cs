using UnityEngine;

public class HightScoreController : MonoBehaviour
{
    [SerializeField] Transform _container;
    [SerializeField] ScoreRecord _scoreRecordPrefab;

    void Awake()
    {
        for(int i=0; i<=4; ++i)
        {
            ScoreRecord record = Instantiate(_scoreRecordPrefab, _container);
            record.SetID(i);
        }
    }
}

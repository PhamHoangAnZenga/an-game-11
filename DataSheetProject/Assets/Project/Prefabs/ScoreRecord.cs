using TMPro;
using UnityEngine;

public class ScoreRecord : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    int _id;

    void OnEnable()
    {
        float timer = PlayerPrefs.GetFloat($"Timer{_id}");
        int score = PlayerPrefs.GetInt($"Score{_id}");
        _text.text = $"Level: {_id}\n PlayTime: {timer}\n Score: {score}";
    }

    public void SetID(int id)
    {
        _id = id;
    }
}

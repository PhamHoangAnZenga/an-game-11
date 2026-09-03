using TMPro;
using UnityEngine;

public class ScoreRecord : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    public void Set(float timer, int score)
    {
        _text.text = $"PlayTime: {timer} .Score: {score}";
    }
}

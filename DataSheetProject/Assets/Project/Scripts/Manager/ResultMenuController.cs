using TMPro;
using UnityEngine;

public class ResultMenuController : MonoBehaviour
{
    [SerializeField] GameObject _root;
    [SerializeField] GameObject _nextButton;
    [SerializeField] GameObject _resetButton;
    [SerializeField] GameObject[] _star;
    [SerializeField] TextMeshProUGUI _noitice;

    public void OpenWinMenu()
    {
        _root.SetActive(true);
        _nextButton.SetActive(true);
        _resetButton.SetActive(false);

        foreach (GameObject obj in _star) obj.SetActive(true);
        _noitice.text = "YOU WIN !!!";
    }

    public void OpenLoseMenu()
    {
        _root.SetActive(true);
        _nextButton.SetActive(false);
        _resetButton.SetActive(true);
        foreach (GameObject obj in _star) obj.SetActive(false);
        _noitice.text = "YOU LOSE.";
    }
    
    public void CloseMenu()
    {
        _root.SetActive(false);
    }
}

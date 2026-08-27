using UnityEngine;

public class SafeArea : MonoBehaviour
{
    [SerializeField] RectTransform _rootCanvas;
    [SerializeField] RectTransform _rectTransform;

    void Start()
    {
        FixSafeArea();
    }

    void FixSafeArea()
    {
        Vector2 screenMin = ScreenPointToUIPoint(0, 0);
        Vector2 screenMax = ScreenPointToUIPoint(Screen.width, Screen.height);
        Vector2 safeAreaMin = ScreenPointToUIPoint(Screen.safeArea.x, Screen.safeArea.y);
        Vector2 safeAreaMax = ScreenPointToUIPoint(Screen.safeArea.x + Screen.safeArea.width, Screen.safeArea.y + Screen.safeArea.height);

        _rectTransform.offsetMin = safeAreaMin - screenMin;
        _rectTransform.offsetMax = safeAreaMax - screenMax;
    }

    Vector2 ScreenPointToUIPoint(float x, float y)
    {

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _rootCanvas,
            new Vector2(x, y),
            null,
            out Vector2 point
        );
        return point;
    }

}

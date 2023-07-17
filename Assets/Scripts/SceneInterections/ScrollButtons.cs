using UnityEngine;
using UnityEngine.UI;

public class ScrollButtons : MonoBehaviour
{
    private const float ButtonAlfaIndicator = 0.7f;

    [SerializeField] private Events _events;
    [SerializeField] private Button _nextEventButton;
    [SerializeField] private Button _previousEventButton;

    private void OnEnable()
    {
        _events.CurrentChanged += SetActive;
    }

    private void OnDisable()
    {
        _events.CurrentChanged -= SetActive;
    }

    private void SetActive()
    {
        _nextEventButton.interactable = !_events.IsLastIndex();
        _previousEventButton.interactable = !_events.IsFirstIndex();

        SetAlfa(_nextEventButton);
        SetAlfa(_previousEventButton);
    }

    private void SetAlfa(Button button)
    {
        if (button.interactable)
        {
            Color tempColor = button.image.color;
            tempColor.a = 1f;
            button.image.color = tempColor;
        }
        else
        {
            Color tempColor = _nextEventButton.image.color;
            tempColor.a = ButtonAlfaIndicator;
            _nextEventButton.image.color = tempColor;
        }
    }
}

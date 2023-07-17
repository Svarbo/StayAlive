using TMPro;
using UnityEngine;

public class MainText : MonoBehaviour
{
    [SerializeField] private TMP_Text _mainText;
    [SerializeField] private Events _events;

    private void OnEnable()
    {
        _events.CurrentChanged += Switch;
    }

    private void OnDisable()
    {
        _events.CurrentChanged -= Switch;
    }

    public void SwapMainTextObject(TMP_Text newTextObject)
    {
        _mainText = newTextObject;
        Switch();
    }

    private void Switch()
    {
        _mainText.text = _events.CurrentEvent.Description;
    }
}

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FinishDayButton : MonoBehaviour
{
    [SerializeField] private Events _events;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

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
        Debug.Log(_events.AllViewed);
        _button.interactable = _events.AllViewed;
    }
}

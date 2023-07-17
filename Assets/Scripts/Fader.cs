using TMPro;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(Animator))]
public class Fader : MonoBehaviour
{
    [SerializeField] private DaySwitcher _daySwitcher;

    private Animator _animator;
    private TMP_Text _dayNumber;
    private int _fadeAnimationHash = Animator.StringToHash("Fade");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _dayNumber = transform.GetComponentInChildren<TMP_Text>();
    }

    public void Fade()
    {
        ShowCurrentDayNumber();
        _animator.Play(_fadeAnimationHash);
    }

    private void ShowCurrentDayNumber()
    {
        _dayNumber.text = $"Δενό {_daySwitcher.DayNumber}";
    }
}

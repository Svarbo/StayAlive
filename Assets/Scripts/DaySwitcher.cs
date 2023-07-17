using UnityEngine;
using UnityEngine.Events;

public class DaySwitcher : MonoBehaviour
{
    [SerializeField] private int _winDayNumber;

    public event UnityAction DayChanged;
    public event UnityAction DayFinished;

    public int DayNumber { get; private set; }

    public bool IsWinDay => DayNumber == _winDayNumber;

    private void Start()
    {
        DayNumber = 1;
        GoNextDay();
    }

    public void FinishDay()
    {
        DayNumber++;
        DayFinished?.Invoke();
        GoNextDay();
    }

    private void GoNextDay()
    {
        DayChanged?.Invoke();
    }
}

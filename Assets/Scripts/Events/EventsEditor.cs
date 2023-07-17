using UnityEngine;

[RequireComponent(typeof(Events))]
public class EventsEditor : MonoBehaviour
{
    [SerializeField] private EventsData _regularEvents;
    [SerializeField] private EventsData _startEvents;
    [SerializeField] private EventsData _winEvents;
    [SerializeField] private DaySwitcher _daySwitcher;

    private Events _events;

    private void Awake()
    {
        _events = GetComponent<Events>();

        ResetAllPastChoices();
        FillTempEvents();

        AddStartEvent();
    }

    private void OnEnable()
    {
        _daySwitcher.DayFinished += OnDayFinished;
    }

    private void OnDisable()
    {
        _daySwitcher.DayFinished -= OnDayFinished;
    }

    private void OnDayFinished()
    {
        if (_daySwitcher.IsWinDay)
        {
            _events.Clear();
            AddWinEvent();
        }
        else
        {
            _events.PrepareConsequences();
            AddEvent();
        }
    }

    private void AddStartEvent()
    {
        _events.Add(_startEvents.GetRandom());
    }

    private void AddEvent()
    {
        _events.Add(_regularEvents.GetRandom());
    }

    private void AddWinEvent()
    {
        _events.Add(_winEvents.GetRandom());
    }

    private void ResetAllPastChoices()
    {
        _startEvents.ResetPastChoices();
        _regularEvents.ResetPastChoices();
        _winEvents.ResetPastChoices();
    }

    private void FillTempEvents()
    {
        _startEvents.FillTempEventsList();
        _regularEvents.FillTempEventsList();
        _winEvents.FillTempEventsList();
    }
}
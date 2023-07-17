using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [SerializeField] private DaySwitcher _daySwitcher;

    private List<EventData> _data = new List<EventData>();
    private List<EventData> _consequenceEvents = new List<EventData>();
    private int _currentEventIndex = 0;

    public EventData CurrentEvent { get; private set; }
    public bool AllViewed { get; private set; }

    public event UnityAction CurrentChanged;

    private void Start()
    {
        _currentEventIndex = 0;
    }

    private void OnEnable()
    {
        _daySwitcher.DayChanged += ChangeCurrent;
    }

    private void OnDisable()
    {
        _daySwitcher.DayChanged -= ChangeCurrent;
    }

    public void Add(EventData eventData)
    {
        _data.Add(eventData);
    }

    public bool IsLastIndex()
    {
        if (_data.Count == 0 || _currentEventIndex == _data.Count - 1)
            return true;
        else
            return false;
    }

    public bool IsFirstIndex()
    {
        if (_currentEventIndex == 0)
            return true;
        else
            return false;
    }

    public void ChangeFinalChoice(int choiceIndex)
    {
        _data[_currentEventIndex].MakeChoice(choiceIndex);
    }

    public void PrepareConsequences()
    {
        FillConsequences();
        Clear();
        AddConsequences();
    }

    public void Clear()
    {
        _data.Clear();
        _currentEventIndex = 0;
        AllViewed = false;
    }

    public void ChangeCurrentIndex(int deltaValue)
    {
        if (_data.Count == 0)
            _currentEventIndex = 0;
        else
            _currentEventIndex = Mathf.Clamp(_currentEventIndex + deltaValue, 0, _data.Count - 1);

        ChangeCurrent();
    }

    private void ChangeCurrent()
    {
        CurrentEvent = _data[_currentEventIndex];

        if (_currentEventIndex == _data.Count - 1)
            AllViewed = true;

        CurrentChanged?.Invoke();
    }

    private void FillConsequences()
    {
        int finalChoiceIndex;
        EventData consequenceEvent;

        foreach (EventData eventData in _data) 
        { 
            if(eventData.Choices.Count > 0)
            {
                finalChoiceIndex = eventData.FinalChoiceIndex;
                consequenceEvent = eventData.Choices[finalChoiceIndex].ConsequenceEvent;

                if (consequenceEvent != null)
                    _consequenceEvents.Add(consequenceEvent);
            }
        }
    }

    private void AddConsequences()
    {
        foreach(EventData eventData in _consequenceEvents)
            _data.Add(eventData);

        _consequenceEvents.Clear();
    }
}
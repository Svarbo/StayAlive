using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/Events", fileName = "Events")]
public class EventsData : ScriptableObject
{
    [SerializeField, HideInInspector] private List<EventData> _events = new List<EventData>();

    [SerializeField] private EventData _currentEventData;

    private int _currentIndex = 0;
    private List<EventData> _tempEvents = new List<EventData>();

    public void FillTempEventsList()
    {
        _tempEvents.Clear();

        for (int i = 0; i < _events.Count; i++)
            _tempEvents.Add(_events[i]);
    }

    public EventData GetRandom()
    {
        int randomEventIndex = Random.Range(0, _tempEvents.Count);
        EventData randomEvent = _tempEvents[randomEventIndex];
        _tempEvents.RemoveAt(randomEventIndex);

        return randomEvent;
    }

    public void ResetPastChoices()
    {
        foreach (EventData eventData in _events)
            eventData.MakeChoice(0);
    }

    public void AddElement()
    {
        if(_events == null)
            _events = new List<EventData>();

        _currentEventData = new EventData();
        _events.Add(_currentEventData);
        _currentIndex = _events.Count - 1;
    }

    public void RemoveCurrentElement()
    {
        if(_currentIndex > 0)
        {
            _currentEventData = _events[--_currentIndex];
            _events.RemoveAt(++_currentIndex);
        }
        else
        {
            _events.Clear();
            _currentEventData = null;
        }
    }

    public EventData TryGetNextEventData()
    {
        if(_currentIndex < _events.Count - 1)
            _currentIndex++;

        _currentEventData = this[_currentIndex];
        return _currentEventData;
    }

    public EventData TryGetPreviousEventData()
    {
        if (_currentIndex > 0)
            _currentIndex--;

        _currentEventData = this[_currentIndex];
        return _currentEventData;
    }

    public EventData this[int index]
    {
        get
        {
            if (_events != null && index >= 0 && index < _events.Count)
                return _events[index];
            return null;
        }
        set
        {
            if (_events == null)
                _events = new List<EventData>();

            if (index >= 0 && index < _events.Count && value != null)
                _events[index] = value;
            else
                Debug.LogError("Выход за границы массива, либо переданное значение = null");
        }
    }
}

[System.Serializable]
public class EventData
{
    [SerializeField] private string _description;
    [SerializeField] private List<Choice> _choices;
    [SerializeField] private bool _isLoseEvent;

    private int _finalChoice = 0;

    public List<Choice> Choices => _choices;
    public string Description => _description;
    public int FinalChoiceIndex => _finalChoice;
    public bool IsLoseEvent => _isLoseEvent;

    public void MakeChoice(int choiceIndex)
    {
        _finalChoice = choiceIndex;
    }
}

[System.Serializable]
public class Choice
{
    [SerializeField] private string _description;
    [SerializeField] private EventData _consequenceEvent;

    public EventData ConsequenceEvent => _consequenceEvent;
    public string Description => _description;
}

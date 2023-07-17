using UnityEngine;
using UnityEngine.Events;

public class Referee : MonoBehaviour
{
    [SerializeField] private Events _events;
    [SerializeField] private DaySwitcher _daySwitcher;

    public event UnityAction IsLose;
    public event UnityAction IsWin;

    private void OnEnable()
    {
        _events.CurrentChanged += TryDeclareLose;
        _events.CurrentChanged += TryDeclareWin;
    }

    private void OnDisable()
    {
        _events.CurrentChanged -= TryDeclareLose;
        _events.CurrentChanged -= TryDeclareWin;
    }

    private void TryDeclareLose()
    {
        if (_events.CurrentEvent.IsLoseEvent)
            IsLose?.Invoke();
    }

    private void TryDeclareWin()
    {
        if (_daySwitcher.IsWinDay)
            IsWin?.Invoke();
    }
}

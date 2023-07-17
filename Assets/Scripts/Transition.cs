using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private DaySwitcher _daySwitcher;
    [SerializeField] private Fader _fader;
    [SerializeField] private SoundSource _soundSource;

    private void OnEnable()
    {
        _daySwitcher.DayChanged += On;
    }

    private void OnDisable()
    {
        _daySwitcher.DayChanged -= On;
    }

    public void On()
    {
        _fader.Fade();
        _soundSource.PlayTransitionSound();
    }
}

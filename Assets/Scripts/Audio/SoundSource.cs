using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSource : MonoBehaviour
{
    [SerializeField] private AudioClip _highlightingSound;
    [SerializeField] private AudioClip _transitionsSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHighlightingSound()
    {
        _audioSource.PlayOneShot(_highlightingSound);
    }

    public void PlayTransitionSound()
    {
        _audioSource.PlayOneShot(_transitionsSound);
    }
}

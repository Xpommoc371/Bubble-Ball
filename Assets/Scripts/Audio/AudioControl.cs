using UnityEngine;
using UnityEngine.Events;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource1;
    public static UnityEvent<AudioClip> OnPlayClip = new UnityEvent<AudioClip>();

    private void OnEnable()
    {
        OnPlayClip.AddListener(PlayClip);
    }

    private void OnDisable()
    {
        OnPlayClip.RemoveListener(PlayClip);
    }

    private void PlayClip(AudioClip clip)
    {
        if (clip == null) return;
        audioSource1.PlayOneShot(clip);
    }
}

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource aus;

    void Start()
    {
        aus = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(int i)
    {
        aus.clip = audioClips[i];
        aus.Play();
    }
}

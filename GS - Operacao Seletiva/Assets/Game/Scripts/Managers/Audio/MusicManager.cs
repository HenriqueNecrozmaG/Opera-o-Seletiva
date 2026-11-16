using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource aus;
    
    void Awake()
    {
        aus = GetComponent<AudioSource>();
    }

    public void Play(int i)
    {
        aus.clip = audioClips[i];
        aus.Play();
    }

    public void Pause()
    {
        aus.Pause();
    }

    public void UnPause()
    {
        aus.UnPause();
    }

    public void Stop()
    {
        aus.Stop();
    }
}

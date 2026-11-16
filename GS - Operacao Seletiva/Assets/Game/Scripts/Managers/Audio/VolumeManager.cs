using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string floatParameter;
    public int sliderIndex;

    private Slider volumeSlider;
    private static float[] sliderValue = { 5, 5, 5};

    void Awake()
    {
        volumeSlider = GetComponent<Slider>();
    }

    void Start()
    {
        volumeSlider.value = sliderValue[sliderIndex];
    }

    public void OnVolumeChanged(float v)
    {
        audioMixer.SetFloat(floatParameter, v);
        sliderValue[sliderIndex] = volumeSlider.value;
    }
}

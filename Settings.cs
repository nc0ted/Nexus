using Michsky.UI.Shift;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Audio Visualization")]
    [SerializeField] private AudioParse audioParse;
    [SerializeField] private GameObject bands;
    [SerializeField] private SwitchManager audioVisualizeSwitch;
    
    public void SetAudioVisualizerState()
    {
        audioParse.enabled=audioVisualizeSwitch.isOn;
        bands.SetActive(audioVisualizeSwitch.isOn);
    }
}
using System;
using UnityEngine;

public class AudioParse : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public static readonly float[] Samples = new float[512];
    public static readonly float[] FreqBand = new float[8];

    private void Update()
    {
        GetAudioSpectrum();
        MakeFrequencyBands();
    }
    private void GetAudioSpectrum()
    {
        audioSource.GetSpectrumData(Samples, 1, FFTWindow.Blackman);
    }

    private void MakeFrequencyBands()
    {
        int band = 0;
        for (int i = 0; i < FreqBand.Length; i++)
        {
            float frequencySum = 0;
            int sampleCount = (int)Mathf.Lerp(2f, Samples.Length, i / (float)FreqBand.Length);
            print(sampleCount);

            for (int j = band; j < sampleCount; j++)
            {
                frequencySum += Samples[band];
                band++;
            }

            FreqBand[i] = frequencySum;
        }
    }
}

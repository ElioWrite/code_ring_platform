using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TimerViewModel : ViewModel
{
    [SerializeField]
    private float _maxTime;

    [SerializeField]
    private Text _timerText;

    private AudioSource _audioSourceCached;
    public AudioSource AudioSourceCached =>_audioSourceCached ??= GetComponent<AudioSource>();

    private bool _isStarted = false;

    private float _startTime;

    public void StartTimer()
    {
        _startTime = Time.time;
        _isStarted = true;
    }

    public void Update()
    {
        if (_maxTime - (Time.time - _startTime) < 0 && _isStarted)
        {
            AudioSourceCached.Play();
            StopTimer();
        }
            

        if (_isStarted)
            _timerText.text = TimeSpan.FromSeconds(_maxTime - (Time.time - _startTime)).ToString(@"mm\:ss");

        else _timerText.text = TimeSpan.FromSeconds(_maxTime).ToString(@"mm\:ss");
    }



    public void StopTimer()
    {
        _isStarted = false;

        // TODO: звуковой сигнал
    }
}

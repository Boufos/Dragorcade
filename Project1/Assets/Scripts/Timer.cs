using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _timerText;
    [SerializeField] private Windows _windGame;
    public int _minute { get; set; }
    public float _second { get; set; } 

    public delegate void TimerStart();
    public event TimerStart eventTimer;

    private bool _stopTimer = true;


    void Start()
    {
        _minute = 0;
        _second = 5;
        _timerText = GetComponent<Text>();
        _windGame.StopGame += StopTimer;
    }

    private void Update()
    {
        if(_stopTimer)
        {
            StartTimer();
        }
        

    }

    private void StartTimer()
    {
        if (_minute > -1)
        {
            _second -= Time.deltaTime;
            if (_second < 9.5)
            {
                _timerText.text = _minute + ":0" + Mathf.Round(_second).ToString();
            }
            else
            {
                _timerText.text = _minute + ":" + Mathf.Round(_second).ToString();
            }
            if (_second < 0)
            {
                _second = 59;
                _minute--;
            }
        }
        else
        {
            eventTimer?.Invoke();
        }
    }

    private void StopTimer()
    {
        _stopTimer = false; 
    }



}

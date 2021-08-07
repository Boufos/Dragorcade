using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windows : MonoBehaviour
{
    [SerializeField] private Canvas _winArea;
    [SerializeField] private AudioSource _audioWin;
    [SerializeField] private AudioClip _shlinkWin;
    [SerializeField] private Image _rStar;
    [SerializeField] private Image _cStar;
    [SerializeField] private Text _text;
    [SerializeField] private Canvas _loseArea;
    [SerializeField] private AudioSource _audioLose;
    [SerializeField] private AudioClip _shlinkLose;
    [SerializeField] private CirclesController circlesController;
    [SerializeField] private Timer timer;
    [SerializeField] private Animator _loseAnim;
    [SerializeField] private Animator _winAnim;

    private int timeThreeStars = 40;
    private int timeTwoStars = 30;

    private int _startMinute;


    public delegate void Window();
    public event Window StopGame;
    void Start()
    {
        _winArea.enabled = false;
        _rStar.enabled = false;
        _cStar.enabled = false;
        _loseArea.enabled = false;
        _text.enabled = false;
        circlesController.eventCircles += WinWindow;
        timer.eventTimer += LoseWindow;
        _startMinute = timer._minute;
    }

    public void WinWindow()
    {
        circlesController.eventCircles -= WinWindow;
        StopGame?.Invoke();
        _audioWin.PlayOneShot(_shlinkWin);
        Stars();
        FinalTime();
        _winArea.enabled = true;
        _winAnim.SetBool("Start", true);
    }
    public void LoseWindow()
    {
        StopGame?.Invoke();
        _audioLose.PlayOneShot(_shlinkLose);
        _text.text = "0:00";
        _text.enabled = true;
        _loseArea.enabled = true;
        _loseAnim.SetBool("Start", true);
    }

    private void FinalTime()
    {
        if (60-timer._second < 9.5 && _startMinute!=1)
        {
            _text.text = _startMinute - timer._minute + ":0" + Mathf.Abs(60-Mathf.Round(timer._second)).ToString();
        }
        else if (_startMinute!=1)
        {
            _text.text = _startMinute - timer._minute + ":" + Mathf.Abs(60 - Mathf.Round(timer._second)).ToString();
        }
        else if (60 - timer._second < 9.5)
        {
            _text.text = 0 + ":0" + Mathf.Abs(60 - Mathf.Round(timer._second)).ToString();
        }
        else
        {
            _text.text = 0 + ":" + Mathf.Abs(60 - Mathf.Round(timer._second)).ToString();
        }
        _text.enabled = true;
    }

    private void Stars()
    {
        if (timer._minute * 60 + timer._second > timeThreeStars )
        {
            _cStar.enabled = true;
            _rStar.enabled = true;
        }
        else if (timer._minute * 60 + timer._second > timeTwoStars)
        {
            _rStar.enabled = true;
        }
    }
}

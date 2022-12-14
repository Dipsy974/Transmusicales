using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public Song[] allClips; 
    public TMP_Dropdown dropdown;
    public MonSliderMieuxQueCeluiDunity slider;
    public TMP_InputField inputField;

    private float _dspSongTime, _songPosition, _songPositionInBeats, _secPerBeat;
    private bool _isSongPlaying, _wasPaused;
    void Start()
    {
        InitializeList();
        audioSource.clip = allClips[0].audio;
        slider.AddListener(ChangeValue);

        _secPerBeat = 60f / allClips[0].bpm;
    }


    void Update()
    {
        if(_isSongPlaying)
        {

            _songPosition = (float)(AudioSettings.dspTime - _dspSongTime);
            _songPositionInBeats = _songPosition / _secPerBeat;
            inputField.text = _songPositionInBeats.ToString();

            slider.value = _songPosition / audioSource.clip.length;

        }
    }


    public void InitializeList()
    {
        dropdown.options = new List<TMP_Dropdown.OptionData>();
        foreach (var clip in allClips)
        {
            var newOption = new TMP_Dropdown.OptionData(clip.name);
            dropdown.options.Add(newOption);
        }
    }

    public void ChangeValue(float f)
    {
        audioSource.time = f * audioSource.clip.length;
        Debug.Log(audioSource.time);
        _songPosition = f * audioSource.clip.length;
        _songPositionInBeats = _songPosition / _secPerBeat;
        Debug.Log(_songPosition);
        inputField.text = _songPositionInBeats.ToString();

    }

    public void Pause()
    {
        audioSource.Pause();
        Debug.Log(audioSource.time);
        _isSongPlaying = false;
        _wasPaused = true;
        _dspSongTime = (float)AudioSettings.dspTime;
        slider.AddListener(ChangeValue);
    }

    public void ChangeTrack(int index)
    {
        Stop();
        audioSource.clip = allClips[index].audio;
        _isSongPlaying = false;
        inputField.text = "0";
    }
    public void Stop()
    {
        _wasPaused = false;
        audioSource.Stop();
        audioSource.time = 0;
        slider.AddListener(ChangeValue);
        _songPosition = 0;
    }

    public void Play()
    {
        slider.RemoveListener(ChangeValue);
        _dspSongTime = (float)AudioSettings.dspTime - _songPosition ;
        _isSongPlaying = true;
        //_dspSongTime = (float)AudioSettings.dspTime + (_wasPaused ?_songPosition:0);
        audioSource.Play();
    }
}

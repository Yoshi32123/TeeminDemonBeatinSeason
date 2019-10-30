using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundUpdater : MonoBehaviour
{
    public GameObject titleMusic;
    public GameObject demonsComing;
    public GameObject creatingPath;
    public GameObject backNoise;
    public GameObject pathNoise;
    public GameObject buttonClickNoise;
    public GameObject pauseClickNoise;
    private AudioSource titleMusicAS;
    private AudioSource demonsComingAS;
    private AudioSource creatingPathAS;
    private AudioSource backNoiseAS;
    private AudioSource pathNoiseAS;
    private AudioSource buttonClickNoiseAS;
    private AudioSource pauseClickNoiseAS;


    // Start is called before the first frame update
    void Start()
    {
        titleMusicAS = titleMusic.GetComponent<AudioSource>();
        demonsComingAS = demonsComing.GetComponent<AudioSource>();
        creatingPathAS = creatingPath.GetComponent<AudioSource>();
        backNoiseAS = backNoise.GetComponent<AudioSource>();
        pathNoiseAS = pathNoise.GetComponent<AudioSource>();
        buttonClickNoiseAS = buttonClickNoise.GetComponent<AudioSource>();
        pauseClickNoiseAS = pauseClickNoise.GetComponent<AudioSource>();

        titleMusicAS.mute = !MusicFunctionality.MusicEnabled;
        demonsComingAS.mute = !MusicFunctionality.MusicEnabled;
        creatingPathAS.mute = !MusicFunctionality.MusicEnabled;
        backNoiseAS.mute = !SoundFunctionality.SoundEnabled;
        pathNoiseAS.mute = !SoundFunctionality.SoundEnabled;
        buttonClickNoiseAS.mute = !SoundFunctionality.SoundEnabled;
        pauseClickNoiseAS.mute = !SoundFunctionality.SoundEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        titleMusicAS.mute = !MusicFunctionality.MusicEnabled;
        demonsComingAS.mute = !MusicFunctionality.MusicEnabled;
        creatingPathAS.mute = !MusicFunctionality.MusicEnabled;
        backNoiseAS.mute = !SoundFunctionality.SoundEnabled;
        pathNoiseAS.mute = !SoundFunctionality.SoundEnabled;
        buttonClickNoiseAS.mute = !SoundFunctionality.SoundEnabled;
        pauseClickNoiseAS.mute = !SoundFunctionality.SoundEnabled;
    }
}

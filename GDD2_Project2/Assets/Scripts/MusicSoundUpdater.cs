using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundUpdater : MonoBehaviour
{
    public GameObject demonsComing;
    public GameObject creatingPath;
    public GameObject backNoise;
    public GameObject pathNoise;
    private AudioSource demonsComingAS;
    private AudioSource creatingPathAS;
    private AudioSource backNoiseAS;
    private AudioSource pathNoiseAS;


    // Start is called before the first frame update
    void Start()
    {
        demonsComingAS = demonsComing.GetComponent<AudioSource>();
        creatingPathAS = creatingPath.GetComponent<AudioSource>();
        backNoiseAS = backNoise.GetComponent<AudioSource>();
        pathNoiseAS = pathNoise.GetComponent<AudioSource>(); 

        demonsComingAS.mute = !MusicFunctionality.MusicEnabled;
        creatingPathAS.mute = !MusicFunctionality.MusicEnabled;
        backNoiseAS.mute = !SoundFunctionality.SoundEnabled;
        pathNoiseAS.mute = !SoundFunctionality.SoundEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        demonsComingAS.mute = !MusicFunctionality.MusicEnabled;
        creatingPathAS.mute = !MusicFunctionality.MusicEnabled;
        backNoiseAS.mute = !SoundFunctionality.SoundEnabled;
        pathNoiseAS.mute = !SoundFunctionality.SoundEnabled;
    }
}

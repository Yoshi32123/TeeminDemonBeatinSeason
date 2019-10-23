using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicUpdater : MonoBehaviour
{
    public GameObject demonsComing;
    public GameObject creatingPath;
    private AudioSource demonsComingAS;
    private AudioSource creatingPathAS;

    // Start is called before the first frame update
    void Start()
    {
        demonsComingAS = demonsComing.GetComponent<AudioSource>();
        creatingPathAS = creatingPath.GetComponent<AudioSource>();

        demonsComingAS.mute = !MusicFunctionality.MusicEnabled;
        creatingPathAS.mute = !MusicFunctionality.MusicEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        demonsComingAS.mute = !MusicFunctionality.MusicEnabled;
        creatingPathAS.mute = !MusicFunctionality.MusicEnabled;
    }
}

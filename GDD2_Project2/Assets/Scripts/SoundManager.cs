using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Call this function to play the attached sound
    /// </summary>
    public void Play()
    {
        source.Play();
    }

    /// <summary>
    /// Call this function to stop the attached sound
    /// </summary>
    public void Stop()
    {
        source.Stop();
    }
}

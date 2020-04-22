using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;
using Valve.VR;

public class AudioManager : MonoBehaviour
{
    public SteamVR_Action_Boolean headsetOnHead;
    [Tooltip("How many seconds after putting on the hmd should the intro play?")]
    public float secsToPlayIntro = 5.0f;
    public float secsToPlayOpenSafe = 2.0f;
    public Sound[] sounds;

    [HideInInspector]
    public AudioManager instance;

    private bool initIntroCall = false;
    private bool initOpenSafeCall = false;
    private bool headsetOnHeadBool;
    private Sound nowPlaying;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }
    }

    private void Update()
    {
        if(headsetOnHead.stateDown && !initIntroCall)
        {
            StartCoroutine(IntroCallRoutine());
            initIntroCall = true;
        }
    }

    public void Play(string name)
    {
        nowPlaying = Array.Find(sounds, sound => sound.name == name);
        if(nowPlaying == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found");
            return;
        }
        Debug.Log("Playing sound with name: " + name);
        nowPlaying.source.Play();
    }
    private IEnumerator IntroCallRoutine()
    {
        yield return new WaitForSeconds(secsToPlayIntro);
        Play("IntroCall");
    }
    public void OpenSafeCall()
    {
        if(!initOpenSafeCall)
        {
            initOpenSafeCall = true;
            StartCoroutine(OpenSafeCallRoutine());
        }
    }
    private IEnumerator OpenSafeCallRoutine()
    {
        yield return new WaitForSeconds(secsToPlayOpenSafe);
        if(nowPlaying.source.isPlaying)
        {
            nowPlaying.source.Stop();
        }
        Play("OpenSafeCall");
    }
}

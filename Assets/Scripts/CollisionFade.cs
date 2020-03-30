using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CollisionFade : MonoBehaviour
{
    //-----------------------------------------------------------------------------
    // Visible in Inspector
    //-----------------------------------------------------------------------------
    [Tooltip("Whether or not to enable fading of the headset when clipping through objects")]
    public bool enableFade = true;
    [Tooltip("Fade time in/out in seconds")]
    public float fadeTime = 0.5f;
    [Tooltip("What color to fade to")]
    public Color fadeColor = Color.black;
    //-----------------------------------------------------------------------------

    [HideInInspector]
    public bool inCollider;
    void Start()
    {
        inCollider = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(enableFade)
        {
            inCollider = true;
            SteamVR_Fade.Start(Color.black, fadeTime);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(enableFade)
        {
            inCollider = false;
            SteamVR_Fade.Start(Color.clear, fadeTime);
        }
    }
}

using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{
    public GameObject mainSwitchController;
    public GameObject secretSwitchController;
    public GameObject normalLight;
    public GameObject morseLight;
    public GameObject mathNote;
    [Tooltip("Time Multiplier for the morse code 1.0: 1 unit = 1 second. 0.5: 1 unit = 0.5 seconds")]
    public float morseTimeMultiplier = 1.0f;

    private SwitchController mainScript;
    private SwitchController secretScript;
    private bool morseActive = false;
    private AudioSource morseSound;

    void Start()
    {
        mainScript = mainSwitchController.GetComponent<SwitchController>();
        secretScript = secretSwitchController.GetComponent<SwitchController>();
        morseSound = morseLight.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(!morseActive)
        {
            if(!mainScript.active && normalLight.activeSelf)
            {
                normalLight.SetActive(false);
            }
            if(morseLight.activeSelf && !mainScript.active || !secretScript.active)
            {
                morseLight.SetActive(false);
            }
            if (mainScript.active && secretScript.active)
            {
                morseActive = true;
                normalLight.SetActive(false);
                StartCoroutine(Morse());
            }
            else if (mainScript.active && !normalLight.activeSelf)
            {
                normalLight.SetActive(true);
            }
        }
        else
        {
            if(!mainScript.active || !secretScript.active)
            {
                morseActive = false;
                StopAllCoroutines();
                MorseOff();
            }
        }
    }
    IEnumerator Morse()
    {
        normalLight.SetActive(false);
        mathNote.SetActive(true);
        while(morseActive)
        {
            yield return StartCoroutine(G());
            yield return new WaitForSeconds(3 * morseTimeMultiplier);
            yield return StartCoroutine(O());
            yield return new WaitForSeconds(3 * morseTimeMultiplier);
            yield return StartCoroutine(G());
            yield return new WaitForSeconds(3 * morseTimeMultiplier);
            yield return StartCoroutine(H());
            yield return new WaitForSeconds(7 * morseTimeMultiplier);
        }
    }
    IEnumerator G()
    {
        MorseOn();
        yield return new WaitForSeconds(3 * morseTimeMultiplier);
        MorseOff();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOn();
        yield return new WaitForSeconds(3 * morseTimeMultiplier);
        MorseOff();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOn();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOff();
    }
    IEnumerator O()
    {
        MorseOn();
        yield return new WaitForSeconds(3 * morseTimeMultiplier);
        MorseOff();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOn();
        yield return new WaitForSeconds(3 * morseTimeMultiplier);
        MorseOff();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOn();
        yield return new WaitForSeconds(3 * morseTimeMultiplier);
        MorseOff();
    }
    IEnumerator H()
    {
        MorseOn();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOff();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOn();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOff();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOn();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOff();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOn();
        yield return new WaitForSeconds(1 * morseTimeMultiplier);
        MorseOff();
    }
    void MorseOn()
    {
        morseLight.SetActive(true);
        morseSound.Play();
    }
    void MorseOff()
    {
        morseLight.SetActive(false);
        morseSound.Stop();
    }
}

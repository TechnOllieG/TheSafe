using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject mainSwitchController;
    public GameObject secretSwitchController;
    public GameObject normalLight;
    public GameObject morseLight;
    public GameObject mathNote;

    private SwitchController mainScript;
    private SwitchController secretScript;
    private bool morseActive = false;

    void Start()
    {
        mainScript = mainSwitchController.GetComponent<SwitchController>();
        secretScript = secretSwitchController.GetComponent<SwitchController>();
    }
    void Update()
    {
        if(!morseActive)
        {
            if(!mainScript.active && normalLight.activeSelf)
            {
                normalLight.SetActive(false);
            }
            if (mainScript.active && secretScript.active)
            {
                morseActive = true;
                Morse();
            }
            else if (mainScript.active)
            {
                normalLight.SetActive(true);
            }
        }
    }
    IEnumerator Morse()
    {
        normalLight.SetActive(false);
        mathNote.SetActive(true);
    }
    void MorseOn()
    {

    }
    void MorseOff()
    {

    }
}

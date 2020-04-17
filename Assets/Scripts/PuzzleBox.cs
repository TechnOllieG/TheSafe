using UnityEngine;
using System.Linq;

public class PuzzleBox : MonoBehaviour
{
    [Tooltip("Should be bound to the text object to be displayed on the screen.")]
    public GameObject displayText;
    [Tooltip("Should be bound to the material to display when the light is on")]
    public Material litLight;

    public GameObject[] lights;
    private MeshRenderer[] lightRenderers;

    private bool[] activeLights;
    private Material oldLightMaterial;
    [HideInInspector]
    public bool solved = false;

    private void Start()
    {
        displayText.SetActive(false);
        lightRenderers = new MeshRenderer[lights.Length];
        activeLights = new bool[lights.Length];

        for(int i = 0; i < lights.Length; ++i)
        {
            lightRenderers[i] = lights[i].GetComponent<MeshRenderer>();
        }

        oldLightMaterial = lightRenderers[0].material;

        for (int i = 0; i < activeLights.Length; ++i)
        {
            activeLights[i] = false;
        }
    }

    public void UpdateLights(int[] lightIndex)
    {
        foreach (int element in lightIndex)
        {
            if(activeLights[element])
            {
                lightRenderers[element].material = oldLightMaterial;
                activeLights[element] = false;
            }
            else
            {
                lightRenderers[element].material = litLight;
                activeLights[element] = true;
            }
        }
    }
    private void Update()
    {
        if(activeLights.Contains(false))
        {
        }
        else if(!solved)
        {
            solved = true;
            displayText.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaletteManager : MonoBehaviour
{
    [SerializeField] private GameObject pallete0;
    [SerializeField] private GameObject pallete1;
    [SerializeField] private GameObject pallete2;
    [SerializeField] private GameObject pallete3;

    [SerializeField] private List<GameObject> palettes;
    [SerializeField] private int paletteIndex;


    //references
    COntinue continueManager;

    private void OnEnable()
    {
        ResetManager.OnReset += Reset;

    }
    private void OnDisable()
    {
        ResetManager.OnReset -= Reset;
        continueManager.OnContinueClicked.RemoveListener(ChangePaletteToIndexLevel);
    }
    // Start is called before the first frame update
    void Start()
    {
        //references to other scripts
        continueManager = GameObject.FindObjectOfType<COntinue>();
        continueManager.OnContinueClicked.AddListener(ChangePaletteToIndexLevel);

        //add palette objects to list
        palettes = new List<GameObject>();
        palettes.Add(pallete0);
        palettes.Add(pallete1);
        palettes.Add(pallete2);
        palettes.Add(pallete3);

        //set index and turn off all palettes
        paletteIndex = 0;
        SwitchToPallette();
    }

    //If palette Inxdex is not out of bounds, switches to the pallete with paletteindex and increased paleete index
    public void ChangePaletteToIndexLevel()
    {
        if (paletteIndex < palettes.Count-1)
        {
            paletteIndex++;
            SwitchToPallette();
        }
        else
        {
            //TODO deactivate continue btn
        }
    }

    //turns all palettes off and turns current palette on
    public void SwitchToPallette()
    {

        DisableAllPalletes();
        palettes[paletteIndex].SetActive(true);
    }

    //disable all palettes
    private void DisableAllPalletes()
    {
        foreach (GameObject item in palettes)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void Reset()
    {

    }
}

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
    TextChangerRule3 textChanger;

    private void OnEnable()
    {
        ResetManager.OnReset += Reset;


    }
    private void OnDisable()
    {
        ResetManager.OnReset -= Reset;
        continueManager.OnContinueClicked.RemoveListener(ChangePaletteToIndexLevel);
        continueManager.OnContinueClicked.RemoveListener(ChangePalletteAccordingToPaletteHeader);
    }
    // Start is called before the first frame update
    void Start()
    {
        //references to other scripts
        continueManager = GameObject.FindObjectOfType<COntinue>();
        continueManager.OnContinueClicked.AddListener(ChangePaletteToIndexLevel);
        textChanger = GameObject.FindObjectOfType<TextChangerRule3>();
        textChanger.OnPaletteHeaderChanged.AddListener(ChangePalletteAccordingToPaletteHeader);

        //add palette objects to list
        palettes = new List<GameObject>();
        palettes.Add(pallete0);
        palettes.Add(pallete1);
        palettes.Add(pallete2);
        palettes.Add(pallete3);

        //set index and turn off all palettes
        paletteIndex = 0;
        SwitchToPallette(paletteIndex);
    }

    //If palette Inxdex is not out of bounds, switches to the pallete with paletteindex and increased paleete index
    public void ChangePaletteToIndexLevel()
    {
        if (paletteIndex < palettes.Count - 1)
        {
            paletteIndex++;
            SwitchToPallette(paletteIndex);
        }
        else
        {
            //TODO deactivate continue btn
        }
    }

    //turns all palettes off and turns current palette on
    public void SwitchToPallette(int i)
    {

        DisableAllPalletes();
        palettes[i].SetActive(true);
    }

    //disable all palettes
    private void DisableAllPalletes()
    {
        foreach (GameObject item in palettes)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void ChangePalletteAccordingToPaletteHeader()
    {
        int index = -1;
        if (textChanger.GetPaletteHeaderText() == TextChangerRule3.palette0)
        {
            index = 0;
        }
        else if (textChanger.GetPaletteHeaderText() == TextChangerRule3.palette1)
        {
            index = 1;
        }
        else if (textChanger.GetPaletteHeaderText() == TextChangerRule3.palette2)
        {
            index = 2;
        }
        else if (textChanger.GetPaletteHeaderText() == TextChangerRule3.palette3)
        {
            index = 3;
        }
        SwitchToPallette(index);
    }

    private void Reset()
    {

    }
}

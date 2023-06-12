using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PhänoGenoChecker : MonoBehaviour
{
    private ElementAssigner phänotype;
    private ElementAssigner genotype;
    [SerializeField] private GameObject genoObject;
    [SerializeField] private Image phänoImage;
    [SerializeField] private Image genoImage;
    [SerializeField] private Color32 red = new Color32(227, 39, 39, 255);
    [SerializeField] private Color32 green = new Color32(56, 244, 73, 255);

    //checkManager Script
    CheckManager checkManager;
    private void Start()
    {
        checkManager = GameObject.Find("CheckManager").GetComponent<CheckManager>();

    }

    //check if the Geno and Phänotype pair fit together, add the bool to the dictionary of checkmanager and call event
    public bool Verify()
    {
        if(this.transform.childCount != 0 && genoObject.transform.childCount != 0)
        {
            phänotype = this.transform.GetChild(0).GetComponent<ElementAssigner>();
            genotype = genoObject.transform.GetChild(0).GetComponent<ElementAssigner>();
            phänoImage = phänotype.transform.GetChild(0).GetComponent<Image>();
            genoImage = genotype.transform.GetChild(0).GetComponent<Image>();

            if (phänotype != null && genotype != null && phänotype.attribute == genotype.attribute)
            {
                Debug.Log("Its a match!");
                ChangeColor(green);
                return true;
            }
            else
            {
                ChangeColor(red);
                return false;
            }
        }
        else
        {
            Debug.Log("try again!");
            return false;
        }
    }

    private void ChangeColor(Color32 color)
    {
        phänoImage.color = color;
        genoImage.color = color;
    }
}

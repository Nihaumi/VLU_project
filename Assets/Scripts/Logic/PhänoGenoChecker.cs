using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using ColorScript;

public class PhänoGenoChecker : MonoBehaviour
{
    private ElementAssigner phänotype;
    private ElementAssigner genotype;
    [SerializeField] private GameObject genoObject;
    [SerializeField] private Image phänoImage;
    [SerializeField] private Image genoImage;
    //[SerializeField] private Color32 red = new Color32(227, 39, 39, 255);
    //[SerializeField] private Color32 green = new Color32(56, 244, 73, 255);

    //color script 
    Colors colors;

    //verfication ints
    private int empty = 0;
    private int correct = 1;
    private int wrong = 2;


    //checkManager Script
    CheckManager checkManager;
    private void Start()
    {
        checkManager = GameObject.Find("CheckManager").GetComponent<CheckManager>();
        colors = new Colors();
    }

    //check if the Geno and Phänotype pair fit together, add the bool to the dictionary of checkmanager and call event
    public int Verify()
    {
        if(this.transform.childCount != 0 && genoObject.transform.childCount != 0)
        {
            phänotype = this.transform.GetChild(0).GetComponent<ElementAssigner>();
            genotype = genoObject.transform.GetChild(0).GetComponent<ElementAssigner>();
            phänoImage = phänotype.transform.GetChild(0).GetComponent<Image>();
            genoImage = genotype.transform.GetChild(0).GetComponent<Image>();

            if (phänotype != null && genotype != null && phänotype.attribute == genotype.attribute)
            {
                ChangeColor(colors.green);
                return correct;
            }
            else
            {
                ChangeColor(colors.red);
                return wrong;
            }
        }
        else
        {
            if(phänoImage && genoObject.transform.childCount == 0)
            {
                phänoImage.color = colors.invisible;
            }
            if(genoImage && this.transform.childCount == 0)
            {
                genoImage.color = colors.invisible;
            }
            
            return empty;
        }
    }

    private void ChangeColor(Color32 color)
    {
        phänoImage.color = color;
        genoImage.color = color;
    }

}

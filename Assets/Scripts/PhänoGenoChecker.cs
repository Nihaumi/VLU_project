using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PhänoGenoChecker : MonoBehaviour
{
    private ElementAssigner phänotype;
    private ElementAssigner genotype;
    [SerializeField] private GameObject genoObject;

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

            if (phänotype != null && genotype != null)
            {
                Debug.Log("Its a match!");
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.Log("try again!");
            return false;
        }
    }
}

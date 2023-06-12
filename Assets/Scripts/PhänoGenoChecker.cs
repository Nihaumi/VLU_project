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
    CheckManager checkManager = new CheckManager();


    //subscribe to events from checkmanager
    private void OnEnable()
    {
        CheckManager.OnClick += Verify;
    }

    private void OnDisable()
    {
        CheckManager.OnClick -= Verify;
    }

    //check if the Geno and Phänotype pair fit together, add the bool to the dictionary of checkmanager and call event
    private void Verify()
    {
        phänotype = this.transform.GetChild(0).GetComponent<ElementAssigner>();
        genotype = genoObject.transform.GetChild(0).GetComponent<ElementAssigner>();

        if (phänotype != null && genotype != null)
        {
            if (phänotype.attribute == genotype.attribute)
            {
                Debug.Log("Its a match!");

                checkManager.AddCheckToChecklist(this.GetComponent<PhänoGenoChecker>(), true);
            }
            else
            {
                Debug.Log("try again!");
                checkManager.AddCheckToChecklist(this.GetComponent<PhänoGenoChecker>(), false);
            }
        }
        else
        {
            Debug.Log("Fill out all forms");
            checkManager.AddCheckToChecklist(this.GetComponent<PhänoGenoChecker>(), false);
        }


    }
}

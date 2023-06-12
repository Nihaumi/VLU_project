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


    //subscribe to events from checkmanager
    private void OnEnable()
    {
        CheckManager.OnClick += Verify;
    }

    private void OnDisable()
    {
        CheckManager.OnClick -= Verify;
    }
    private void Start()
    {
        checkManager = GameObject.Find("CheckManager").GetComponent<CheckManager>();
    }

    //check if the Geno and Phänotype pair fit together, add the bool to the dictionary of checkmanager and call event
    private void Verify()
    {
        if (this.transform.childCount == 0)
        {
            Debug.Log("Fill out all forms");

            return;
        }
        else
        {


            phänotype = this.transform.GetChild(0).GetComponent<ElementAssigner>();
            genotype = genoObject.transform.GetChild(0).GetComponent<ElementAssigner>();

            if (phänotype != null && genotype != null)
            {
                if (phänotype.attribute == genotype.attribute)
                {
                    Debug.Log("Its a match!");
                    // if (!checkManager.GetChecklist().ContainsKey(this.gameObject.name))
                    checkManager.AddCheckToChecklist(this.gameObject.name, true);
                }
                else
                {
                    Debug.Log("try again!");
                    if (!checkManager.GetChecklist().ContainsKey(this.gameObject.name))
                        checkManager.AddCheckToChecklist(this.gameObject.name, false);
                }
            }
        }


        checkManager.ControllChecklist();
    }
}

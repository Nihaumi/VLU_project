using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TextManager;

public class CheckManager : MonoBehaviour
{

    //events
    public delegate void ClickAction();
    public static event ClickAction OnClick;
    public static event ClickAction OnCheck;

    //unity events
    public UnityEvent OnCheckCall;

    //list of structure spots
    public Dictionary<string, bool> checkList = new Dictionary<string, bool>();

    public List<PhänoGenoChecker> namelist = new List<PhänoGenoChecker>();
    [SerializeField] private List<int> verificationlist = new List<int>();

    public int structureSize;

    //references
    TextChanger textChanger;

    public void CheckBtnClicked()
    {
        foreach(PhänoGenoChecker item in namelist)
        {
            int temp = item.Verify();
            verificationlist.Add(temp);
        }
        if(!verificationlist.Contains(1) && verificationlist.Contains(0) && !verificationlist.Contains(2))
        {
            textChanger.SetText(TextChanger.empty, TextChanger.emptyHeading);
        }
       else if (verificationlist.Contains(1) && verificationlist.Contains(0) && !verificationlist.Contains(2))
        {
            textChanger.SetText(TextChanger.soFarGood, TextChanger.soFarGoodHeading);
        }
       else if (verificationlist.Contains(2))
        {
            textChanger.SetText(TextChanger.fail, TextChanger.failHeading);
        }
       
        else if(verificationlist.Contains(1) && !verificationlist.Contains(0) && !verificationlist.Contains(2))
        {
            textChanger.SetText(TextChanger.success, TextChanger.successHeading);
        }

        verificationlist.Clear();

    }

    private void Start()
    {
        AddChildrenToList("F0");
        AddChildrenToList("F1");

        textChanger = GameObject.FindObjectOfType<TextChanger>();
    }

    //fills list with slots containing the checker script
    private void AddChildrenToList(string parent)
    {
        GameObject parentObject = GameObject.Find(parent).gameObject;
        for (int i = 0; i < parentObject.transform.childCount - 1; i++)
        {
            Transform child = parentObject.transform.GetChild(i);
            if (child.GetComponent<PhänoGenoChecker>())
                namelist.Add(child.GetComponent<PhänoGenoChecker>());
        }
    }
}

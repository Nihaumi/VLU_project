using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TextManager;

public class MultipleCheckManager : MonoBehaviour
{

    //events
    public delegate void ClickAction();
    public static event ClickAction OnClick;
    public static event ClickAction OnCheck;

    //unity events
    public UnityEvent OnCheckCall;

    //list of structure spots
    public Dictionary<string, bool> checkList = new Dictionary<string, bool>();

    public List<MultiplePhänoGenoChecker1> namelist = new List<MultiplePhänoGenoChecker1>();
    [SerializeField] private List<int> verificationlist = new List<int>();

    [SerializeField] private GameObject Gen1;
    [SerializeField] private GameObject Gen2;
    [SerializeField] private GameObject Gen3;
    [SerializeField] private GameObject Gen4;
    [SerializeField] private GameObject Gen5;

    public int structureSize;

    //references
    TextChanger textChanger;

    public void CheckBtnClicked()
    {
        foreach(MultiplePhänoGenoChecker1 item in namelist)
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
        FillList();
        textChanger = GameObject.FindObjectOfType<TextChanger>();
    }

    public void FillList()
    {
        namelist.Clear();
        //AddChildrenToList(Gen1);
        AddChildrenToList(Gen2);
        AddChildrenToList(Gen3);
        AddChildrenToList(Gen4);
        AddChildrenToList(Gen5);

    }

    //fills list with slots containing the checker script
    private void AddChildrenToList(GameObject parent)
    {
        if (!parent.activeInHierarchy)
        {
            return;
        }
        GameObject parentObject = parent;
        for (int i = 0; i < parentObject.transform.childCount - 1; i++)
        {
            Transform child = parentObject.transform.GetChild(i);
            if (child.GetComponent<MultiplePhänoGenoChecker1>())
                namelist.Add(child.GetComponent<MultiplePhänoGenoChecker1>());
        }
    }
}

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
    public List<MultiplePhänoGenoChecker1> namelistF1Keimzellen = new List<MultiplePhänoGenoChecker1>();
    public List<MultiplePhänoGenoChecker1> namelistKeimzellen = new List<MultiplePhänoGenoChecker1>();
    public List<MultiplePhänoGenoChecker1> namelistF2 = new List<MultiplePhänoGenoChecker1>();
    [SerializeField] private List<int> verificationlist = new List<int>();

    //parent objects that contain children with multiplechecker in them --> geno and phänoslots
    [SerializeField] private GameObject Gen1;
    [SerializeField] private GameObject Gen2;
    [SerializeField] private GameObject Gen3;
    [SerializeField] private GameObject Gen4;
    [SerializeField] private GameObject Gen5;

    //could be useless but idk
    public int structureSize;

    //tells which level of the scheme we are on currently/ how many times the continue buttom was clicked
    [SerializeField] private int levelIndex;

    //references
    TextChanger textChanger;
    PaletteManager paletteManager;
    COntinue continueManager;

    private void OnEnable()
    {
        
    }

    public void CheckBtnClicked()
    {
        IncreaseLevelInedex();

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
        paletteManager = GameObject.FindObjectOfType<PaletteManager>();
        continueManager = GameObject.FindObjectOfType<COntinue>();
     
        levelIndex = 0;
    }

    private void IncreaseLevelInedex()
    {
        levelIndex++;
    }

    private void SetCurrentList(List<MultiplePhänoGenoChecker1> list)
    {
        namelist.Clear();
        namelist = list;
    }

    //fills list with geno and phänoslots so we can compare them later
    public void FillList()
    {
        namelist.Clear();
        //AddChildrenToList(Gen1);
        AddChildrenToList(Gen2, namelistF1Keimzellen);
        AddChildrenToList(Gen3, namelistKeimzellen);
        AddChildrenToList(Gen4, namelistF2);
        AddChildrenToList(Gen5, namelistF2);

    }

    //fills list with slots containing the checker script
    private void AddChildrenToList(GameObject parent, List<MultiplePhänoGenoChecker1> list)
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
                list.Add(child.GetComponent<MultiplePhänoGenoChecker1>());
        }
    }
}

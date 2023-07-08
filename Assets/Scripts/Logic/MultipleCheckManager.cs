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
    [SerializeField] private int hintPageIndex;

    //references
    [SerializeField] TextChangerRule3 textChanger;
    PaletteManager paletteManager;
    COntinue continueManager;

    private void OnEnable()
    {

    }

    public void CheckBtnClicked()
    {

        foreach (MultiplePhänoGenoChecker1 item in namelist)
        {
            int temp = item.Verify();
            verificationlist.Add(temp);
        }
        if (!verificationlist.Contains(1) && verificationlist.Contains(0) && !verificationlist.Contains(2))
        {
            //textChanger.SetText(TextChangerRule3.empty, TextChangerRule3.emptyHeading);
        }
        else if (verificationlist.Contains(1) && verificationlist.Contains(0) && !verificationlist.Contains(2))
        {
            //textChanger.SetText(TextChangerRule3.soFarGood, TextChangerRule3.soFarGoodHeading);
        }
        else if (verificationlist.Contains(2))
        {
            //textChanger.SetText(TextChangerRule3.fail, TextChangerRule3.failHeading);
        }

        else if (verificationlist.Contains(1) && !verificationlist.Contains(0) && !verificationlist.Contains(2))
        {
            textChanger.SetText(TextChangerRule3.success, TextChangerRule3.successHeading);
            levelIndex = 5;
            SetTextAndListAccordingToCurrentIndex(levelIndex);
            textChanger.SetPagination((hintPageIndex + 1).ToString() + "/" + (levelIndex + 1).ToString());
        }

        verificationlist.Clear();

    }
    private void OnDisable()
    {
        continueManager.OnContinueClicked.RemoveListener(SetIndexAndTextAndList);
    }
    private void Start()
    {
        //references to other scripts
        textChanger = GameObject.FindObjectOfType<TextChangerRule3>();
        paletteManager = GameObject.FindObjectOfType<PaletteManager>();
        continueManager = GameObject.FindObjectOfType<COntinue>();
        continueManager.OnContinueClicked.AddListener(SetIndexAndTextAndList);

        FillList();

        levelIndex = 0;
        hintPageIndex = 0;
        SetTextAndListAccordingToCurrentIndex(levelIndex);
        textChanger.SetPagination((hintPageIndex + 1).ToString() + "/" + (levelIndex + 1).ToString());
    }

    //set the tutorial Text according to what level in the scheme we are on

    public void ShowPreviousHint()
    {
        if(hintPageIndex > 0)
        {
            hintPageIndex--;
        }
        SetTextAndListAccordingToCurrentIndex(hintPageIndex);
        textChanger.SetPagination((hintPageIndex + 1).ToString() + "/" + (levelIndex + 1).ToString());
    }

    public void ShowNextHint()
    {
        if (hintPageIndex < levelIndex)
        {
            hintPageIndex++;
        }
        SetTextAndListAccordingToCurrentIndex(hintPageIndex);
        textChanger.SetPagination((hintPageIndex+1).ToString() + "/" + (levelIndex+1).ToString());
    }


    private void SetTextAndListAccordingToCurrentIndex(int i)
    {
        string currentText = "";
        string currentHeading = "";
        string paletteText = "";
        int index = i;
        switch (index)
        {
            case 0:
                currentText = TextChangerRule3.introRow1;
                currentHeading = TextChangerRule3.introHeading;
                paletteText = TextChangerRule3.palette0;
                break;
            case 1:
                currentText = TextChangerRule3.introRow2;
                currentHeading = TextChangerRule3.introRow2Heading;
                paletteText = TextChangerRule3.palette1;
                break;
            case 2:
                currentText = TextChangerRule3.introRow3;
                currentHeading = TextChangerRule3.introRow3Heading;
                paletteText = TextChangerRule3.palette2;
                break;
            case 3:
                currentText = TextChangerRule3.introRow4;
                currentHeading = TextChangerRule3.introRow4Heading;
                paletteText = TextChangerRule3.palette3;
                break;
            default:
                currentText = "";
                currentHeading = "something went wrong";
                break;
        }
        textChanger.SetText(currentText, currentHeading);
        textChanger.SetPaletteHeader(paletteText);
    }

    private void SetIndexAndTextAndList()
    {
        if (levelIndex >= 3) { return; }
        levelIndex++;
        hintPageIndex = levelIndex;
        SetTextAndListAccordingToCurrentIndex(levelIndex);
        textChanger.SetPagination((hintPageIndex + 1).ToString() + "/" + (levelIndex + 1).ToString());
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
        AddChildrenToList(Gen2, namelist);
        AddChildrenToList(Gen3, namelist);
        AddChildrenToList(Gen4, namelist);
        AddChildrenToList(Gen5, namelist);

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

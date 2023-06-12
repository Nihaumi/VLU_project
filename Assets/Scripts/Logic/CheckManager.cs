using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

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
    [SerializeField] private List<bool> verificationlist = new List<bool>();

    public int structureSize;

    public void CheckBtnClicked()
    {
        foreach(PhänoGenoChecker item in namelist)
        {
            bool temp = item.Verify();
            verificationlist.Add(temp);
        }

        if (verificationlist.Contains(false))
        {
            Debug.Log("Try again");
        }
        else
        {
            Debug.Log("You did it!");
        }

        verificationlist.Clear();

    }

    private void Start()
    {
        AddChildrenToList("F0");
        AddChildrenToList("F1");
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

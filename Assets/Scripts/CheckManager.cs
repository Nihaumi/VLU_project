using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckManager
{
    //events
    public delegate void ClickAction();
    public static event ClickAction OnClick;
    public static event ClickAction OnCheck;


    //list of structure spots
    Dictionary<PhänoGenoChecker, bool> checkList = new Dictionary<PhänoGenoChecker, bool>();

    [SerializeField] private int checkableStructureItemCount;


    public void CheckBtnClicked()
    {
        OnClick();
        if(checkList.Count == checkableStructureItemCount)
        {

        }
    }

    private void ControllChecklist()
    {
        foreach(var checkItem in checkList)
        {
            if(checkList.ContainsValue(false))
            {
                Debug.Log($"Error Found: {checkList.Keys}, {checkList.Values}");
            }
        }
    }

    public void AddCheckToChecklist(PhänoGenoChecker typeChek, bool isCorrect)
    {
        checkList.Add(typeChek, isCorrect);
    }
}

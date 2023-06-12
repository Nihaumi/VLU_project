using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public int structureSize;

    //subscribe to events
    private void OnEnable()
    {
        OnCheckCall.AddListener(ControllChecklist);
    }

    private void OnDisable()
    {
        OnCheckCall.RemoveListener(ControllChecklist);
    }

    public void CheckBtnClicked()
    {
        OnClick();

    }

    public Dictionary<string, bool> GetChecklist()
    {
        return checkList;
    }
    public void ControllChecklist()
    {
        

        foreach (var checkItem in checkList)
        {
            if (checkList.ContainsValue(false))
            {
                Debug.Log("There seems to be a mistake. Try again.");
            }
            else
            {
                if (checkList.Count < structureSize)
                {
                    Debug.Log("It looks good so far. Continue to fill the structure.");
                }
                else
                {
                    Debug.Log("All looks well");
                    Debug.Log($"Count : {checkList.Count}");
                }
            }

        }
        checkList.Clear();
    }

    public void AddCheckToChecklist(string Slot, bool isCorrect)
    {
        checkList.Add(Slot, isCorrect);


    }
}

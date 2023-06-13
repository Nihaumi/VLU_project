using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    //events
    public static event CheckManager.ClickAction OnReset;

    public void Reset()
    {
        OnReset();
    }
}

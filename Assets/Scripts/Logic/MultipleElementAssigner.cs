using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleElementAssigner : MonoBehaviour
{
    public enum GenoPh�noType
    {
        GenoTyp,
        Ph�noTyp,
        F1GenoTyp,
        F1Ph�noTyp
    };
    public GenoPh�noType genoPh�notype;

    public enum FirstAttribute
    {
        DomDom,
        DomRez,
        RezDom,
        RezRez
    };
    public FirstAttribute firtsAttribute;

    public enum LastAttribute
    {
        DomDom,
        DomRez,
        RezDom,
        RezRez
    };
    public LastAttribute lastAttribute;

    public GameObject ogParent;

    private void Start()
    {
        ogParent = this.transform.parent.gameObject;
    }

    private void OnEnable()
    {
        ResetManager.OnReset += Reset;
    }

    private void OnDisable()
    {
        ResetManager.OnReset -= Reset;
    }
    private void Reset()
    {
        this.transform.SetParent(ogParent.transform);

        this.transform.localPosition = new Vector3(0, 0, 0);
    }
}

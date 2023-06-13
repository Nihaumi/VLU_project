using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementAssigner : MonoBehaviour
{
    public enum GenoPhänoType
    {
        GenoTyp,
        PhänoTyp,
        F1GenoTyp,
        F1PhänoTyp
    };
    public GenoPhänoType genoPhänotype;

    public enum Attribute
    {
        DomDom,
        DomRez,
        RezDom,
        RezRez
    };
    public Attribute attribute;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAssigner : MonoBehaviour
{
    public enum GenoPh�noType
    {
        GenoTyp,
        Ph�noTyp,
        F1GenoTyp,
        F1Ph�noTyp
    };
    public GenoPh�noType genoPh�notype;

    public enum Attribute
    {
        AA,
        Aa,
        aA,
        aa
    };
    public Attribute attribute;

}

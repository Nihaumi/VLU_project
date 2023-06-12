using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineManager : MonoBehaviour
{
    //outlineshape enum
    public enum Shape
    {
        square,
        other
    }
    public Shape outlineshape;

    [SerializeField] private GameObject[] outlines = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        outlines = GameObject.FindGameObjectsWithTag("outline");

        if (outlineshape == Shape.other)
        {
            foreach(GameObject outline in outlines)
            {
                Color32 tmp = outline.GetComponent<Image>().color;
                outline.GetComponent<Image>().color = new Color32(tmp.r, tmp.g, tmp.b, 0);
            }
        }
    }
}

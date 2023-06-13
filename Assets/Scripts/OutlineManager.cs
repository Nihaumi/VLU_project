using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ColorScript;

public class OutlineManager : MonoBehaviour
{
    //outlineshape enum
    public enum Shape
    {
        square,
        other
    }
    public Shape PhänoOutlineshape;
    public Shape GenoOutlineshape;

    Colors colors = new Colors();

    [SerializeField] private GameObject[] PhänoOutlines = new GameObject[6];
    [SerializeField] private GameObject[] GenoOutlines = new GameObject[6];
    

    // Start is called before the first frame update
    void Start()
    {
        PhänoOutlines = GameObject.FindGameObjectsWithTag("outline");
        GenoOutlines = GameObject.FindGameObjectsWithTag("genoOutline");

        ChangeOutlineColor(PhänoOutlines, PhänoOutlineshape);
        ChangeOutlineColor(GenoOutlines, GenoOutlineshape);
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
        ChangeOutlineColor(PhänoOutlines, PhänoOutlineshape);
        ChangeOutlineColor(GenoOutlines, GenoOutlineshape);
    }

    private void ChangeOutlineColor(GameObject[] array, Shape shape)
    {
        Color32 color;

        if (shape == Shape.other)
        {
            color = colors.invisible;   
        }
        else
        {
            color = colors.white;
        }
        foreach (GameObject outline in array)
        {
            Color32 tmp = outline.GetComponent<Image>().color;
            outline.GetComponent<Image>().color = color;
        }


    }
}

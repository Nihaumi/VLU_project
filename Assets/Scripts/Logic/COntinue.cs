using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COntinue : MonoBehaviour
{
    [SerializeField] private GameObject scrollContent;
    [SerializeField] private GameObject scrollbar;
    [SerializeField] private int contentIndex = 1;
    [SerializeField] private float scrollValue = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        contentIndex = 1;
        HideScrollContent();
    }

    public void ShowNextScrollContentElement()
    {
        if (contentIndex < scrollContent.transform.childCount)
        {
            GetScrollContentElement(contentIndex).SetActive(true);
            if (contentIndex == scrollContent.transform.childCount - 2)
            {
                GetScrollContentElement(contentIndex + 1).SetActive(true);
                contentIndex++;
            }
            contentIndex++;
            scrollbar.GetComponent<Scrollbar>().value = scrollValue;
        }
     
    }
    private GameObject GetScrollContentElement(int index)
    {

        return scrollContent.transform.GetChild(index).gameObject;
    }
    private void HideScrollContent()
    {
        for(int i = 1; i < scrollContent.transform.childCount; i++)
        {
            GetScrollContentElement(i).SetActive(false);

        }
    }
}

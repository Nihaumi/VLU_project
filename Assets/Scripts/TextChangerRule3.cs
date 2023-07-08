using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChangerRule3 : MonoBehaviour
{
    [SerializeField] private TMP_Text guideTxt;
    [SerializeField] private TMP_Text guideTxtHeading;
    [SerializeField] private Animation animation;
    [SerializeField] private TMP_Text pagination;

    static public string tutorial = "Ziehe die Elemente auf der Rechten Seite per DragnDrop auf die roten Felder in der Darstellung.";
    static public string tutorialHeading = "Tutorial";

    static public string introRow1 = "Hier kreuzen wir Erbsen, die sich in 2 Merkmalen unterscheiden: \n\nSamenfarbe: \nGG <color=yellow>gelb</color>  oder \ngg <color=green>Gr�n</color> \n\nSamenform \n<i><b>RR rund</b> oder \nrr <b>rau</b></i> \n\n diese Merkmale werden unabh�ngig voneinander vererbt.";
    static public string introHeading = "Unabh�ngigkeitsregel";

    static public string introRow2 = "Pro Merkmal wird 1 Allel auf die Keimzellen verteilt. \n\nIn der F1 Generation sind die Allele f�r gelb und glatte Samen <i><b>dominant</b></i>, wie im Ph�notyp zu sehen. \n\nOrdne jetzt die richtigen Genotypen der F1 Generation per Drag und Drop zu.";
    static public string introRow2Heading = "Unabh�ngigkeitsregel";

    static public string introRow3 = "Alle Nachkommen in der F1 Generation weisen den <i><b>gleichen Genotypen</b></i> auf. \n\nDie Allele k�nnen nun wieder unabh�ngig vererbt und kombiniert werden. Welche m�glichen kombinationen gibt es in den Keimzellen?";
    static public string introRow3Heading = "Unabh�ngigkeitsregel";

    static public string introRow4 = "In der F2 Generation entstehen 16 neue Kombinationen. \n\nOrde Ihnen die Genotypen zu. \n\nDie Kombinationen sollten im Verh�ltnis von <i><b>9:3:3:1</b></i> auftreten.";
    static public string introRow4Heading = "Unabh�ngigkeitsregel";

    static public string success = "Super! Dein Verst�ndnis f�r dieses Thema ist sehr gut! \n\nMache jetzt den Test der Lektion oder schaue im Forum vorbei um dich mit anderen auszutauschen..";
    static public string successHeading = "Alles Richtig!";

    static public string fail = "Die Geno - und Ph�notypen passen nicht zusammen. \n\nSieh dir nochmal die Lektionen an oder Frage im Forum andere Lernende.";
    static public string failHeading = "Noch nicht ganz.";

    static public string soFarGood = "Das sieht gut aus! Du hast das Prizip verstanden. \n\nF�lle die restliche Darstellung aus.";
    static public string soFarGoodHeading = "Weiter So!";

    static public string emptyHeading = "Leere Darstellung";
    static public string empty = tutorial;

    public void SetText(string text, string heading)
    {
        animation.Play();
        guideTxt.text = text;
        guideTxtHeading.text = heading;
        //animator.ResetTrigger("TextChange");

    }

    public void SetPagination(string text)
    {
        pagination.text = text;
    }

    private void Start()
    {
        //SetText(tutorial, tutorialHeading);
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
        SetText(tutorial, tutorialHeading);
    }


}

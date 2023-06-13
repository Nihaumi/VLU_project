using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TextManager
{
    public class TextChanger : MonoBehaviour
    {
        [SerializeField] private TMP_Text guideTxt;
        [SerializeField] private TMP_Text guideTxtHeading;

        static public string tutorial = "Ordne die Genotypen den entsprehenden Phänotypen zu. \n\nZiehe dazu die Elemente auf der Rechten Seite per DragnDrop auf die roten Felder in der Darstellung.";
        static public string tutorialHeading = "Tutorial";

        static public string success = "Super! Dein Verständnis für dieses Thema ist sehr gut! \n\nMache jetzt den Test der Lektion oder schaue im Forum vorbei um dich mit anderen auszutauschen..";
        static public string successHeading = "Alles Richtig!";

        static public string fail = "Anscheinend hast du Verständnislücken. \n\nSieh dir nochmal die Lektionen an oder Frage im Forum andere Lernende.";
        static public string failHeading = "Noch nicht ganz.";

        static public string soFarGood = "Das sieht gut aus! Du hast das Prizip verstanden. \n\nFülle die restliche Darstellung aus.";
        static public string soFarGoodHeading = "Weiter So!";

        static public string emptyHeading = "Leere Darstellung";
        static public string empty = tutorial;

        public void SetText(string text, string heading)
        {
            guideTxt.SetText(text);
            guideTxtHeading.SetText(heading);
        }


        private void Start()
        {
            SetText(success, tutorialHeading);
        }




    }
}
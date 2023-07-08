using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TextManager
{
    public class TextCahngerUnabhängiigkeitsregel : MonoBehaviour
    {
        [SerializeField] private TMP_Text guideTxt;
        [SerializeField] private TMP_Text guideTxtHeading;
        [SerializeField] private Animation animation;

        static public string tutorial = "Ziehe die Elemente auf der Rechten Seite per DragnDrop auf die roten Felder in der Darstellung.";
        static public string tutorialHeading = "Tutorial";

        static public string introRow1 = "Hier kreuzen wir Erbsen, die sich in 2 Merkmalen unterscheiden: \n\nSamenfarbe GG gelb oder gg Grün \n\nSamenform RR rund oder rr rau \n\n diese Merkmale werden unabhängig voneinander vererbt.";
        static public string introHeading = "Unabhängigkeitsregel";
        
        static public string introRow2 = "Pro Merkmal wird 1 Allel auf die Keimzellen verteilt. \n\nIn der F1 Generation sind die Allele für gelbe und glatte Samen dominant, wie im Phänotyp zu sehen. \n\n Ordne jetzt die richtigen Genotypen der F1 Generation per Drag und Drop zu.";
        static public string introRow2Heading = "Unabhängigkeitsregel";

        static public string introRow3 = "Richtig. Alle Nachkommen in der F1 Generation weisen den gleichen Genotypen auf. \n\nDie Allele können nun wieder unabhängig vererbt und kombiniert werden. Welche möglichen kombinationen gibt es in den Keimzellen? Nutze wieder den Drasg & Drop";
        static public string introRow3Heading = "Unabhängigkeitsregel";

        static public string success = "Super! Dein Verständnis für dieses Thema ist sehr gut! \n\nMache jetzt den Test der Lektion oder schaue im Forum vorbei um dich mit anderen auszutauschen..";
        static public string successHeading = "Alles Richtig!";

        static public string fail = "Die Geno - und Phänotypen passen nicht zusammen. \n\nSieh dir nochmal die Lektionen an oder Frage im Forum andere Lernende.";
        static public string failHeading = "Noch nicht ganz.";

        static public string soFarGood = "Das sieht gut aus! Du hast das Prizip verstanden. \n\nFülle die restliche Darstellung aus.";
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


        private void Start()
        {
            SetText(tutorial, tutorialHeading);
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
}
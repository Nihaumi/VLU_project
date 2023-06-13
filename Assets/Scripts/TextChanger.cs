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
        [SerializeField] private Animation animation;

        static public string tutorial = "Ordne die Genotypen den entsprehenden Ph�notypen zu. \n\nZiehe dazu die Elemente auf der Rechten Seite per DragnDrop auf die roten Felder in der Darstellung.";
        static public string tutorialHeading = "Tutorial";

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
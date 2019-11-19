namespace RPGKit.Dialogue
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class Option : MonoBehaviour
    {
        public Text displayText;

        public void SetText(string text)
        {
            displayText.text = text;
        }
    }

}
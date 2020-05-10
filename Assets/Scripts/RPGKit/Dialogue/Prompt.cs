namespace RPGKit.Dialogue {
    using UnityEngine;
    using System.Collections.Generic;

    [AddComponentMenu("RPGKit/Dialogue/Dialogue Prompt")]
    public class Prompt : MonoBehaviour
    {
        public List<PromptOption> options;
        public int response = -1;

        public Prompt(List<PromptOption> options)
        {
            this.options = options;
        }

        public static readonly int Unanswered = -1;
    }

    [System.Serializable]
    public struct PromptOption {
        public string text;
        public bool available;
    }
}


namespace RPGKit.Dialogue {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Options : MonoBehaviour
    {
        public Option optionPrefab;
        public RectTransform parent;

        public void Start()
        {
            if (!parent) parent = GetComponent<RectTransform>();
            DisplayPrompt(Samples.OfferWarriorMercPrompt);
        }

        public void DisplayPrompt(Prompt prompt)
        {
            foreach(Transform t in parent) Destroy(t.gameObject);
            for (int i = 0; i < prompt.GetOptionCount(); i++)
                Instantiate(optionPrefab, parent).SetText(prompt.GetOption(i));
        }
    }

}
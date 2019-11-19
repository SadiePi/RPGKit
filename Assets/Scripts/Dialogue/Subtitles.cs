namespace RPGKit.Dialogue {
    using UnityEngine;
    using UnityEngine.UI;

    public class Subtitles : MonoBehaviour
    {
        public Text text;

        public Color nameColor;
        public Color speechColor;

        public void DisplayLine(Line line)
        {
            text.text = string.Format("<color=#{0}>{1}: </color><color=#{2}>{3}</color>",
                ColorUtility.ToHtmlStringRGBA(nameColor),
                line.speaker.GetName(),
                ColorUtility.ToHtmlStringRGBA(speechColor),
                line.text
             );
        }

        public void Clear()
        {
            text.text = "";
        }

        public void Start()
        {
            Clear();
            //DisplayLine(new Line(new Speaker("Tester"), "Hello, world!"));
        }
    }
}
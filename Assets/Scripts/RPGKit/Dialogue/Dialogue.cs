namespace RPGKit.Dialogue {
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;

    [AddComponentMenu("RPGKit/Dialogue/Dialogue")]
    public class Dialogue : MonoBehaviour
    {
        public string dialogueName;
        public Controller controller;
        public List<Line> lines;
        private int currentLineIndex = Controller.Start;

        public Dialogue(List<Line> lines, Controller controller)
        {
            this.lines = lines;
            this.controller = controller;
        }

        public Line GetCurrentLine() { return (currentLineIndex >= 0 && currentLineIndex < lines.Count) ? lines[currentLineIndex] : null; }
        public bool Advance()
        {
            if (currentLineIndex == Controller.End) return false;
            Line currentLine = GetCurrentLine();
            currentLineIndex = controller.Continue(currentLineIndex, currentLine?.prompt);
            return currentLine != null;
        }

        

        [MenuItem("RPGKit/Do The Thing!")]
        static void TheThing() {
            
        }
    }

    [System.Serializable]
    public class Line
    {
        public Speaker speaker;
        public string text;
        public string sound;
        public Prompt prompt;

        public Line(Speaker speaker, string text, Prompt prompt)
        {
            this.speaker = speaker;
            this.text = text;
            this.prompt = prompt;
        }
    }
}
namespace RPGKit.Dialogue {
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;

    // TODO: Event-ize this whole thing

    [AddComponentMenu("RPGKit/Dialogue/Dialogue")]
    public class Dialogue : MonoBehaviour
    {
        public string dialogueName;
        public Controller controller;
        public Line[] lines;
        private int currentLineIndex = Controller.Start;

        public Dialogue(Line[] lines, Controller controller)
        {
            this.lines = lines;
            this.controller = controller;
        }

        public Line GetCurrentLine() { return (currentLineIndex >= 0 && currentLineIndex < lines.Length) ? lines[currentLineIndex] : null; }
        public bool Advance()
        {
            if (currentLineIndex == Controller.End) return false;
            Line currentLine = GetCurrentLine();
            currentLineIndex = controller.Continue(currentLineIndex, currentLine?.prompt);
            if(currentLineIndex >= lines.Length) currentLineIndex = Controller.End;
            return currentLineIndex != Controller.End;
        }

        public void Reset() {
            currentLineIndex = Controller.Start;
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
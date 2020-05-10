namespace RPGKit.Dialogue {
    using UnityEngine;

    public abstract class Controller : MonoBehaviour
    {
        public abstract int Continue(int currentLineIndex, Prompt answeredPrompt);

        public static readonly int Start = -1;
        public static readonly int End = -2;
    }
}
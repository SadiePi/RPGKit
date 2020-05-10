namespace RPGKit.Dialogue {
    using UnityEngine;

    public abstract class Controller : MonoBehaviour
    {
        public abstract int Continue(int currentLineIndex, Prompt answeredPrompt);

        public static readonly int Start = -1;
        public static readonly int End = -2;
    }

    [AddComponentMenu("Test")]
    public class LinearDialogueController : Controller {
        public override int Continue(int currentLineIndex, Prompt answeredPrompt) {
            return currentLineIndex + 1;
        }
    }
    public class OneRandomLine : Controller {
        public Dialogue toControl;

        public override int Continue(int currentLineIndex, Prompt answeredPrompt) {
            if(currentLineIndex != Start) return End;
            return (int)Mathf.Floor(Random.Range(0, toControl.lines.Count));
        }
    }
}
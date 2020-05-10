
namespace RPGKit.Dialogue {
    using UnityEngine;
    [AddComponentMenu("RPGKit/Dialogue/One Random Line Controller")]
    public class OneRandomLineController : Controller {
        public Dialogue toControl;

        public override int Continue(int currentLineIndex, Prompt answeredPrompt) {
            if(currentLineIndex != Start) return End;
            return (int)Mathf.Floor(Random.Range(0, toControl.lines.Length));
        }
    }
}
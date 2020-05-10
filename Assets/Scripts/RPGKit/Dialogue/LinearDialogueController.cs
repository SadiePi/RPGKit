
namespace RPGKit.Dialogue {
    using UnityEngine;
    [AddComponentMenu("RPGKit/Dialogue/Linear Dialogue Controller")]
    public class LinearDialogueController : Controller {
        public override int Continue(int currentLineIndex, Prompt answeredPrompt) {
            return currentLineIndex + 1;
        }
    }
}
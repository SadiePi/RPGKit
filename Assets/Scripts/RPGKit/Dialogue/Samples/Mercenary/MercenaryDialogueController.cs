using UnityEngine;
using RPGKit.Dialogue;

public class MercenaryDialogueController : Controller
{
    public bool rejected;
    public override int Continue(int currentLineIndex, Prompt answeredPrompt) {
        if (currentLineIndex == Start)
            {
                if (rejected) return 10;
                return 0;
            }

            if(currentLineIndex == 8)
            {
                rejected = true;
                return End;
            }

            
            if (currentLineIndex == 0 || currentLineIndex == 7)
            {
                switch (answeredPrompt.response)
                {
                    case 0:
                        // start charging 150g/d
                        return 8;
                    case 1: return 1;
                    case 2: return 9;
                }
            }

            return currentLineIndex + 1;
    }
}

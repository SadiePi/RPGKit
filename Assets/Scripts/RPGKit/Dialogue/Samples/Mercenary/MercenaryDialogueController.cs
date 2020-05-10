using UnityEngine;
using RPGKit.Dialogue;

public class MercenaryDialogueController : Controller
{
    public bool rejected;
    public override int Continue(int currentLineIndex, Prompt prompt) {
        if (currentLineIndex == Start)
        {
            if (rejected) return 10;
            return 0;
        }

        if(currentLineIndex == 8)
        {
            // start charging 150g/d
            return End;
        }

        if(currentLineIndex == 9) 
        {
            rejected = true;
            return End;
        }

        
        if (currentLineIndex == 0 || currentLineIndex == 7 || currentLineIndex == 10)
        {
            switch (prompt.response)
            {
                case 0: return 8;
                case 1: return 1;
                case 2: return 9;
            }
        }

        return currentLineIndex + 1;
    }
}

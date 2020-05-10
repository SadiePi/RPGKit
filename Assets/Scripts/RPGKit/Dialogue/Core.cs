namespace RPGKit.Dialogue {
    
    

    

    /*public sealed class Samples
    {
        public static bool OfferWariorMercRejected = false;
        public static Prompt OfferWarriorMercPrompt = new Prompt("Come with me (150g/d)", "How good are you?", "Another time perhaps");
        public static Dialogue OfferWarriorMerc = new Dialogue(new Line[]
        {
            new Line("My prowess with a blade is for sale... if you have the coin", OfferWarriorMercPrompt),
            "My training began when I was a lad of just 5 years",
            "The smallest of my siblings, I had to train all day and night just to keep up",
            "Past our childhood, this determination carried me to the top of the military ranks",
            "And beyond",
            "I soon realized my talents were wasted on the beuracracy of organized military",
            "So now I'm here, offering victory to those smart enough to take it",
            new Line("Are you?", OfferWarriorMercPrompt),
            "Then your victory is secured",
            "You know where to find me",
            new Line("So you've returned. Come to your senses, have you?", OfferWarriorMercPrompt)

        }, (current, prompt) =>
        {
            if (current == Dialogue.Start)
            {
                if (OfferWariorMercRejected) return 10;
                return 0;
            }

            if(current == 8)
            {
                OfferWariorMercRejected = true;
                return Dialogue.End;
            }

            
            if (current == 0 || current == 7)
            {
                switch (prompt.GetResponse())
                {
                    case 0:
                        // start charging 150g/d
                        return 8;
                    case 1: return 1;
                    case 2: return 9;
                }
            }

            return current + 1;

        });

        public static Dialogue Hello = new Dialogue(new Line[] {
            "Hello",
            "I'm a simple dialogue",
            "I don't ask any questions, I don't check any conditions",
            "Simple, if a little boring"
        }, Dialogue.LinearDialogue);

        public static Dialogue PoliteGreeting = new Dialogue(new Line[]
        {
            "Hello",
            "Hail, traveller",
            "Lovely weather",
            "Welcome!"
        }, Dialogue.OneRandomLine(4));
    }*/
}
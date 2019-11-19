namespace RPGKit.Dialogue
{
    using UnityEngine;

    public class Speaker
    {
        private string name;
        public string GetName()
        {
            return name == null ? implicitSpeaker?.name : name;
        }

        public Speaker(string name)
        {
            this.name = name;
        }

        public static Speaker implicitSpeaker = new Speaker("Unasigned Implicit Speaker");
        public static void SetImplicitSpeaker(Speaker speaker) { implicitSpeaker = speaker; }
    }

    public class Prompt
    {
        string[] options;
        int response = Unanswered;

        public Prompt(params string[] options)
        {
            this.options = options;
        }

        public int GetOptionCount() { return options.Length; }
        public string GetOption(int index) { return options[index]; }

        public void SetResponse(int index) { response = index; }
        public int GetResponse() { return response; }

        public static readonly int Unanswered;
    }

    public class Line
    {
        public Speaker speaker;
        public string text;
        public Prompt prompt;

        public Line(Speaker speaker, string text, Prompt prompt)
        {
            this.speaker = speaker;
            this.text = text;
            this.prompt = prompt;
        }
        public Line(string text, Prompt prompt) : this(null, text, prompt) { }
        public Line(Speaker speaker, string text) : this(speaker, text, null) { }
        public Line(string text) : this(null, text, null) { }

        public static implicit operator Line(string text) { return new Line(text); }
    }

    public delegate int Controller(int currentLine, Prompt prompt);
    public class Dialogue : Object
    {

        private Line[] lines;
        private Controller controller;
        private int currentLine = Start;

        public Dialogue(Line[] lines, Controller controller)
        {
            this.lines = lines;
            this.controller = controller;
        }

        public Line GetCurrentLine() { return (currentLine >= 0 && currentLine < lines.Length) ? lines[currentLine] : null; }
        public bool Advance()
        {
            if (currentLine == End) return false;
            currentLine = controller(currentLine, GetCurrentLine()?.prompt);
            return GetCurrentLine() != null;
        }

        public static readonly int Start = -1;
        public static readonly int End = -2;
        public static Controller LinearDialogue = (c, p) => c + 1;
        public static Controller OneRandomLine(int numberOfOptions)
        {
            return (c, p) => { if (c != Start) return End; return (int)Mathf.Floor(Random.Range(0, numberOfOptions)); };
        }
    }

    public sealed class Samples
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
                Speaker.SetImplicitSpeaker(new Speaker("Wandering Mercenary"));
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
                        // todo: start charging 150g/d
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
        }, Dialogue.OneRandomLine(5));
    }
}
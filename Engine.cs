using Rotorclass;
using languages;
namespace Engineclass;
class Engine
    {
        public char[] Key = new char[3];
        private Rotor InputRotor = new Rotor();
        private Rotor OutputRotor = new Rotor();
        private Rotor Reflector = new Rotor();
        private Dictionary<char, char> RotorDictRef;
        private Dictionary<char, char> RotorDictStd;
        private List<Rotor> Rotors = new List<Rotor>()
        {
            new Rotor(), new Rotor(), new Rotor()
        };
        public string lang;
        private Languages languages = new Languages();
        
        public Engine()
        {
            RotorDictRef = languages.EnRDictRef;
            RotorDictStd = languages.EnRDictStd;
            lang = "en";
        }

        private char RotorCommutation(char letter, Rotor outputRotor, Rotor inputRotor)
        {
            char[] outputLine = outputRotor.GetRotorLine();
            char[] inputLine = inputRotor.GetRotorLine();

            int letterIndex = Array.IndexOf(outputLine, letter);
            char result = inputRotor.GetLetter(inputLine[letterIndex]);

            return result;
        }

        public void Init()
        {
            Rotors[0].SetRotorKey(Key[2]);
            Rotors[1].SetRotorKey(Key[1]);
            Rotors[2].SetRotorKey(Key[0]);
            Reflector.SetRotorDict(RotorDictRef);
            InputRotor.SetRotorDict(RotorDictStd);
            OutputRotor.SetRotorDict(RotorDictStd);
            Console.WriteLine($"You setted next key: |{Rotors[2].CheckKey()}|{Rotors[1].CheckKey()}|{Rotors[0].CheckKey()}|");
        }

        private void TurnRotor()
        {
            Rotors[0].Turn();
            if (Rotors[0].RoundCounter == 0)
            {
                Rotors[1].Turn();
              if (Rotors[1].RoundCounter == 0)
                    Rotors[2].Turn();
            }
        }

        public char GetNewLetter(char letter)
        {
            TurnRotor();
            try
            {
                char firstRes = RotorCommutation(letter, InputRotor, Rotors[0]);
                char secondRes = RotorCommutation(firstRes, Rotors[0], Rotors[1]);
                char thirdRes = RotorCommutation(secondRes, Rotors[1], Rotors[2]);
                char reflectedRes = RotorCommutation(thirdRes, Rotors[2], Reflector);
                char fourthRes = RotorCommutation(reflectedRes, Reflector, Rotors[2]);
                char fifthRes = RotorCommutation(fourthRes, Rotors[2], Rotors[1]);
                char sixthRes = RotorCommutation(fifthRes, Rotors[1], Rotors[0]);
                char seventhRes = RotorCommutation(sixthRes, Rotors[0], InputRotor);

                return seventhRes;
            }

            catch
            {
                throw new ArgumentException("RotorCommutation error");
            }
                        
        }

        public void SetLang(string lang)
        {
            switch (lang)
            {
                case "ru":
                    RotorDictStd = languages.RuRDictStd;
                    RotorDictRef = languages.RuRDictRef;
                    InputRotor.Lang(languages.RuRLine, languages.RuRDict);
                    OutputRotor.Lang(languages.RuRLine, languages.RuRDict);
                    Reflector.Lang(languages.RuRLine, languages.RuRDict);
                    foreach (Rotor i in Rotors)
                        i.Lang(languages.RuRLine, languages.RuRDict);
                    this.lang = "ru";
                    Console.WriteLine("Теперь вы можете шифровать сообщения на Русском языке.");
                    break;

                case "en":
                    RotorDictStd = languages.EnRDictStd;
                    RotorDictRef = languages.EnRDictRef;
                    InputRotor.Lang(languages.EnRLine, languages.EnRDict);
                    OutputRotor.Lang(languages.EnRLine, languages.EnRDict);
                    Reflector.Lang(languages.EnRLine, languages.EnRDict);
                    foreach (Rotor i in Rotors)
                        i.Lang(languages.EnRLine, languages.EnRDict);
                    this.lang = "en";
                    Console.WriteLine("Now you can encrypt messages in English");
                    break;

                default:
                    Console.WriteLine("Enigma doesn't support this language.");
                    break;
            }
        }
    }
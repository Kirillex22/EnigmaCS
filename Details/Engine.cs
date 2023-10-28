using static MyConstants.Constants;

namespace EnigmaLib
{
    public class Engine
    {
        public char[] Key = new char[3];

        private Rotor Stator = new();

        private Rotor Reflector = new();

        private List<Rotor> Rotors = new List<Rotor>()
        {
            new(), new(), new()
        };

        public string Lang = English;


        public Engine()
        {
            SetLang(Lang);
            Rotors[RtstRotor].Name = "Right";
            Rotors[1].Name = "Middle";
            Rotors[2].Name = "Left";
        }


        private char RotorCommutation(char letter, Rotor outputRotor, Rotor inputRotor)
        {
            char[] outputLine = outputRotor.GetRotorLine();
            char[] inputLine = inputRotor.GetRotorLine();

            int letterIndex = Array.IndexOf(outputLine, letter);
            char result = inputRotor.Commutate(inputLine[letterIndex]);

            return result;
        }       


        public void Init()
        {
            int k = Rotors.Count() - 1;

            foreach (Rotor i in Rotors)
                i.SetRotorLineDefault(Lang);

            for(int i = 0; i <= k; i++)
                Rotors[i].SetRotorKey(Key[k - i]);
        }


        private void TurnRotor()
        {
            int k = Rotors.Count() - 1;

            Rotors[RtstRotor].Turn();

            for (int i = 0; i <= k; i++)
            {
                if (Rotors[i].RoundCounter == StartPoint)
                    Rotors[(i + 1)%k].Turn();
                else
                    break;
            }

        }


        public char GetNewLetter(char letter)
        {
            TurnRotor();

            try
            {
                char fRes = RotorCommutation(letter, Stator, Rotors[0]);
                char sRes = RotorCommutation(fRes, Rotors[0], Rotors[1]);
                char tRes = RotorCommutation(sRes, Rotors[1], Rotors[2]);
                char refRes = RotorCommutation(tRes, Rotors[2], Reflector);
                char foRes = RotorCommutation(refRes, Reflector, Rotors[2]);
                char fiRes = RotorCommutation(foRes, Rotors[2], Rotors[1]);
                char siRes = RotorCommutation(fiRes, Rotors[1], Rotors[0]);
                char result = RotorCommutation(siRes, Rotors[0], Stator);
                          
                return result;
                
            }

            catch
            {
                throw new ArgumentException("Getting new letter error");
            }

        }


        public void SetLang(string Lang)
        {
            switch (Lang)
            {
                case Russian:
                    Stator.Lang(Languages.RuRLine, Languages.RuRDictStd, Languages.RuSTDKey);
                    Reflector.Lang(Languages.RuRLine, Languages.RuRDictRef, Languages.RuSTDKey);
                    foreach (Rotor i in Rotors)
                        i.Lang(Languages.RuRLine, Languages.RuRDict, Languages.RuSTDKey);
                    this.Lang = Russian;
                    break;

                case English:
                    Stator.Lang(Languages.EnRLine, Languages.EnRDictStd, Languages.EnSTDKey);
                    Reflector.Lang(Languages.EnRLine, Languages.EnRDictRef, Languages.EnSTDKey);
                    foreach (Rotor i in Rotors)
                        i.Lang(Languages.EnRLine, Languages.EnRDict, Languages.EnSTDKey);
                    this.Lang = English;
                    break;

                default:
                    break;
            }
        }

    }
}
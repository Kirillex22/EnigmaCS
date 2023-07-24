using languages;
namespace Rotorclass;
class Rotor
    {
       private Languages languages = new Languages();
        private char[] RotorLine;
        private Dictionary<char, char> RotorDict;
        public char Key;
        public int RoundCounter = 0;

        public Rotor()
        {
            RotorLine = languages.EnRLine;
            RotorDict = languages.EnRDict;
            Key = 'a';
        }

        public void SetRotorKey(char Key)
        {
            if (Array.IndexOf(RotorLine, Key) == -1)
                throw new ArgumentException("Language is different");
            this.Key = Key;
            int displacement = Array.IndexOf(RotorLine, Key);
            while(displacement != 0)
            {
                Turn();
                displacement--;
            }
        }

        private void SetRoundCounter()
        {
            if (RoundCounter == RotorLine.Length)
                RoundCounter = 0;
            else
                RoundCounter++;
        }

        public void Turn()
        {
            try
            {
                char startLetter = RotorLine[0];
                SetRoundCounter();

                for (int i = 0; i < RotorLine.Length; i++)
                {
                    if (i == RotorLine.Length - 1)
                        RotorLine[i] = startLetter;
                    else
                        RotorLine[i] = RotorLine[i + 1];
                }
            }

            catch
            {
                throw new ArgumentException("Rotor's turn error");
            }
            
        }

        public char GetLetter(char letter)
        {
            try
            {
                return RotorDict.GetValueOrDefault(letter);
            }

            catch
            {
                throw new ArgumentException("Letter getting error");
            }
             
        }

        public void SetRotorDict(Dictionary<char, char> RotorDict)
        {
            this.RotorDict = RotorDict;
        }

        public char[] GetRotorLine()
        {
            return RotorLine;
        }

        public char CheckKey()
        {
            return Key;
        }

        public void Lang(char[] RotorLine, Dictionary<char, char> RotorDict)
        {
            this.RotorLine = RotorLine;
            this.RotorDict = RotorDict;
        }
    }
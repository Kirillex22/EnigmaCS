using static MyConstants.Constants;

namespace EnigmaLib
{
    public class Rotor
    {
        public string Name = Empty;

        private char[] RotorLine;

        private Dictionary<char, char> RotorDict;

        public char? Key;

        public int RoundCounter = StartPoint;


        public void SetRotorKey(char Key)
        {
            RoundCounter = StartPoint;

            if (Array.IndexOf(RotorLine, Key) == -1)
                throw new ArgumentException("SetRotorKey error");

            this.Key = Key;
            int displacement = Array.IndexOf(RotorLine, Key);

            while (displacement != 0)
            {
                Turn(Initial);
                displacement--;
            }

        }


        private void Counter()
        {
            if (RoundCounter == RotorLine.Length)
                RoundCounter = StartPoint;
            else
                RoundCounter++;
        }


        public void Spin(char startLetter)
        {
            for (int i = 0; i < RotorLine.Length; i++)
            {
                if (i == RotorLine.Length - 1)
                    RotorLine[i] = startLetter;
                else
                    RotorLine[i] = RotorLine[i + 1];
            }
            
        }


        public void Turn()
        {
            try
            {
                char startLetter = RotorLine[StartPoint];

                Counter();

                Spin(startLetter);
            }

            catch
            {
                throw new ArgumentException("Turn error");
            }

        }


        public void Turn(int freedomVal)
        {
            if (freedomVal == Initial)
            {
                try
                {
                    char startLetter = RotorLine[StartPoint];                  

                    Spin(startLetter);
                }

                catch
                {
                    throw new ArgumentException("Turn error");
                }
            }

        }


        public char Commutate(char letter)
        {
            char result = RotorDict.GetValueOrDefault(letter);

            if (result != default)
                return result;
            else
                throw new ArgumentException("Commutate error");
        }


        public void SetRotorDict(Dictionary<char, char> RotorDict)
        {
            this.RotorDict = RotorDict;
        }


        public char[] GetRotorLine()
        {
            if (RotorLine != null)
                return RotorLine;
            else
                throw new Exception("GetRotorLine error");
        }


        public void Lang(char[] RotorLine, Dictionary<char, char> RotorDict, char Key)
        {
            this.RotorLine = RotorLine;
            this.RotorDict = RotorDict;
            this.Key = Key;
        }


        public void SetRotorLineDefault(string Lang)
        { 
            if (Lang == Russian)
                RotorLine = Languages.RuRLine;
            else if (Lang == English)
                RotorLine = Languages.EnRLine;
        }
    }

}

namespace Rotorclass;
class Rotor
    {
        private char[] RotorLine = new char[]
        {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z', ' ',
        };


        private Dictionary<char, char> RotorDict = new Dictionary<char, char>()
        {
            {'a', 'z'}, {'b', 'y'}, {'c', 'x'}, {'d', 'w'}, {'e', 'v'},
            {'f', 'u'}, {'g', 't'}, {'h', 's'}, {'i', 'r'}, {'j', 'q'},
            {'k', 'p'}, {'l', 'o'}, {'m', 'n'}, {'n', 'm'}, {'o', 'l'},
            {'p', 'k'}, {'q', 'j'}, {'r', 'i'}, {'s', 'h'}, {'t', 'g'},
            {'u', 'f'}, {'v', 'e'}, {'w', 'd'}, {'x', 'c'}, {'y', 'b'},
            {'z', 'a'}, {' ', ' '}
        };

        public char Key = 'a';

        public int RoundCounter = 0;

        public void SetRotorKey(char Key)
        {
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
            char startLetter = RotorLine[0];
            SetRoundCounter();   

            for (int i = 0; i < RotorLine.Length; i++)
            {
                if (i == RotorLine.Length - 1)
                    RotorLine[i] = startLetter;
                else
                    RotorLine[i] = RotorLine[i+1];
            }
        }

        public char GetLetter(char letter)
        {
            return RotorDict.GetValueOrDefault(letter);
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

        public void SetRotorLine(char[] RotorLine)
        {
            this.RotorLine = RotorLine;
        }
    }
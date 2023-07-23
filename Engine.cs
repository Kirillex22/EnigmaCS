using Rotorclass;

namespace Engineclass;
class Engine
    {
        private Rotor InputRotor = new Rotor();
        private Rotor OutputRotor = new Rotor();

        private List<Rotor> Rotors = new List<Rotor>() 
        { 
            new Rotor(), new Rotor(), new Rotor()
        };

        private Rotor Reflector = new Rotor();

        private Dictionary<char, char> RotorDictRef = new Dictionary<char, char>() 
        {
            {'a', 'f'}, {'b', 'g'}, {'c', 'h'}, {'d', 'i'}, {'e', 'j'},
            {'f', 'a'}, {'g', 'b'}, {'h', 'c'}, {'i', 'd'}, {'j', 'e'},
            {'k', 'p'}, {'l', 'q'}, {'m', 'r'}, {'n', 's'}, {'o', 't'},
            {'p', 'k'}, {'q', 'l'}, {'r', 'm'}, {'s', 'n'}, {'t', 'o'},
            {'u', 'v'}, {'v', 'u'}, {'w', 'x'}, {'x', 'w'}, {'y', 'z'},
            {'z', 'y'}, {' ', ' '} 
        };

        private Dictionary<char, char> RotorDictStd = new Dictionary<char, char>()
        {
            {'a', 'a'}, {'b', 'b'}, {'c', 'c'}, {'d', 'd'}, {'e', 'e'},
            {'f', 'f'}, {'g', 'g'}, {'h', 'h'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}, {' ', ' '}
        };

        public char[] Key = new char[3];

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

        private char RotorPipeLine(char letter, List<Rotor> Rotors) 
        {
            char result = RotorCommutation(letter, InputRotor, Rotors[0]);

            for(int i = 0; i < Rotors.Count - 1; i++)
            {
                result = RotorCommutation(result, Rotors[i], Rotors[i + 1]);
            }

            result = RotorCommutation(result, Rotors[Rotors.Count - 1], OutputRotor);

            return result;

        }

        private char RotorPipeLine(char letter, Rotor Reflector, List<Rotor> Rotors)
        {
            char result = RotorCommutation(letter, InputRotor, Rotors[0]);

            for (int i = 0; i < Rotors.Count - 1; i++)
            {
                result = RotorCommutation(result, Rotors[i], Rotors[i + 1]);
            }

            result = RotorCommutation(result, Rotors[Rotors.Count - 1], Reflector);

            result = RotorCommutation(result, Reflector, Rotors[Rotors.Count - 1]);

            for (int i = Rotors.Count - 1; i > 1; i--)
            {
                result = RotorCommutation(result, Rotors[i], Rotors[i - 1]);
            }

            result = RotorCommutation(result, Rotors[0], InputRotor);

            return result;

        }

        public char GetNewLetter(char letter)
        {
            TurnRotor();

            char firstRes = RotorCommutation(letter, InputRotor, Rotors[0]);
            char secondRes = RotorCommutation(firstRes, Rotors[0], Rotors[1]);
            char thirdRes = RotorCommutation(secondRes, Rotors[1], Rotors[2]);
            char reflectedRes = RotorCommutation(thirdRes, Rotors[2], Reflector);
            char fourthRes = RotorCommutation(reflectedRes, Reflector, Rotors[2]);
            char fifthRes = RotorCommutation(fourthRes, Rotors[2], Rotors[1]);
            char sixthRes = RotorCommutation(fifthRes, Rotors[1], Rotors[0]);
            char seventhRes = RotorCommutation(sixthRes, Rotors[0], InputRotor);
            //char result = RotorPipeLine(letter, Reflector, Rotors);

            return seventhRes;
        }
    }
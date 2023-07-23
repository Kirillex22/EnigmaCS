using Engineclass;

namespace Enigmaclass;

class Enigma
    {
        private Engine engine = new Engine();

        public void SetKey(string Key)
        {
            engine.Key = Key.ToCharArray();
            engine.Init();
        }

        public char Ecnrypt(char letter)
        {
            return engine.GetNewLetter(letter);
        }

        public Engine GetEngine()
        {
            return engine;
        }
    }
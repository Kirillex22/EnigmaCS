using static MyConstants.Constants;

namespace EnigmaLib
{
    public class Enigma
    {
        private Engine MyEngine = new();

        private string Key = Default;


        public Enigma()
        {
            SetKey(Key);
        }


        public void SetKey(string Key)
        {
            this.Key = Key;
            Reboot();
        }


        public char Encrypt(char letter)
        {
            return MyEngine.GetNewLetter(letter);
        }


        public string Encrypt(string message)
        {
            string result = Empty; 

            foreach (char i in message)
                result += MyEngine.GetNewLetter(i);

            return result;
        }


        public void Reboot()
        {
            char[] NewKey = Key.ToCharArray();
            MyEngine.Key = NewKey;
            MyEngine.Init();
        }


        public void SwithLang(string Lang)
        {
            MyEngine.SetLang(Lang);
        }


        public string GetLang()
        {
            return MyEngine.Lang;
        }

    }
}

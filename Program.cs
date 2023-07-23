using Enigmaclass;

namespace program;
internal class Program
{

    static void Main(string[] args)
    {
        char[] input;
        Enigma enigma = new Enigma();
        string key = Console.ReadLine();
        enigma.SetKey(key);
        input = Console.ReadLine().ToLower().ToCharArray();
        char[] result = new char[input.Length];
        int k = 0;
        foreach(char i in input)
        {
            result[k] = enigma.Ecnrypt(i);
            k++;
        }

        foreach (char i in result)
        {
            Console.Write(i);
        }

    }
}

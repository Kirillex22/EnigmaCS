using EnigmaLib;

namespace Program;
internal class Program
{

    static void Main(string[] args)
        {
            string input;
            Enigma enigma = new Enigma();
            char pressedKey;
            bool opened = true;
            while(opened)
            {
                Console.Clear();
                Console.WriteLine("1. Шифрование");
                Console.WriteLine($"2. Сменить локализацию [текущая {enigma.GetLang()}]");
                Console.WriteLine("3. Закрыть программу");

                pressedKey = Console.ReadKey().KeyChar;

                if (pressedKey == '1')
                {   
                    try
                    {
                        Console.Clear();
                        Console.WriteLine($"Введите ключ длины 3. [текущий язык: {enigma.GetLang()}]");
                        Console.WriteLine();
                        string key = Console.ReadLine();
                        Console.WriteLine();
                        enigma.SetKey(key);
                        Console.WriteLine();
                        while (pressedKey == '1')
                        {
                            Console.WriteLine("Ввод сообщения: ");
                            Console.WriteLine();
                            input = Console.ReadLine();

                            string result = enigma.Encrypt(input);
                           
                            Console.WriteLine();
                            Console.WriteLine("Зашифрованное сообщение");
                            Console.WriteLine();
                            Console.WriteLine(result);
                            Console.WriteLine();
                            Console.WriteLine("1. Вернуться к шифровке.");
                            Console.WriteLine("2. В меню");
                            pressedKey = Console.ReadKey().KeyChar;
                            Console.Clear();
                        }
                    }
                    
                    catch
                    {
                        Console.WriteLine("Проверьте правильность языка ввода");
                        Console.ReadKey();
                        pressedKey = '4';
                    }                                    
                    
                }

                else if (pressedKey == '2')
                {
                    Console.Clear();
                    Console.WriteLine("1. ru");
                    Console.WriteLine("2. en");
                    pressedKey = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    Console.WriteLine();
                    if (pressedKey == '1')
                        enigma.SwithLang("ru");
                    else if (pressedKey == '2')
                        enigma.SwithLang("en");
                    Console.ReadKey();
                }

                else if (pressedKey == '3')
                    opened = false;
            }
        }
}

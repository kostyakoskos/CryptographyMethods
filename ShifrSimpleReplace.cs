using System;
using System.Text;
using System.IO;

namespace ShifrSimpleReplace
{
    class Program
    {
        static void Main()
        {
            char[,] keys = new char[66, 2];// 66 for all russian alphabet

            using (TextReader reader = new StreamReader(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrSimpleReplace\\key.txt", Encoding.Default)) //путь и имя файла
            {
                string str;
                char[] myStr = new char[2];// for every input srtring for 2 char
                int count = 0;
                while ((str = reader.ReadLine()) != null) //пока читается
                {
                    myStr = str.ToCharArray();// every string to 2 char
                    keys[count, 0] = str[0];
                    keys[count, 1] = str[1];
                    count++;
                }
            }
            do
            {
                uint k = 0;
                string s = "";
                string result = "";
                Console.WriteLine("1 to crypt, 2- decrypt");
                while ((k != 1) && (k != 2))
                {
                    uint.TryParse(Console.ReadLine(), out k);
                    if ((k != 1) && (k != 2))
                        Console.WriteLine("Input mistake");
                }
                //crypt
                if (k == 1)
                {
                    string path = @"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrSimpleReplace\\decrypt.txt";
                    Console.WriteLine("String reading drom file!");
                    s = File.ReadAllText(path, Encoding.Default);
                    //crypt
                    //cycle for every char of string
                    for (int i = 0; i < s.Length; i++)
                    {
                        for (int z = 0; z < 66; z++)
                        {
                            if (String.Equals(s[i], keys[z, 0]))
                            {
                                result += keys[z, 1];
                                break;
                            }
                        }
                    }
                    //Вывод на экран зашифрованной строки
                    Console.WriteLine("String successfully crypt!");
                    StreamWriter sr = new StreamWriter(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrCezar\\crypt.txt", false);
                    sr.Write(result);
                    sr.Close();
                    Console.WriteLine(result);
                }
                //decrypt
                if (k == 2)
                {
                    Console.WriteLine("String reading from file!");
                    StreamReader sr = new StreamReader(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrSimpleReplace\\in.txt");
                    s = sr.ReadToEnd();
                    sr.Close();
                    for (int i = 0; i < s.Length; i++)
                    {
                        for (int z = 0; z < 66; z++)
                        {
                            if (String.Equals(s[i], keys[z, 1]))
                            {
                                result += keys[z, 0];
                                break;
                            }

                        }
                    }
                    StreamWriter sr1 = new StreamWriter(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrSimpleReplace\\decrypt.txt", false);
                    sr1.Write(result);
                    sr1.Close();
                    Console.WriteLine(result);
                }
                Console.WriteLine("To Exit input Escape");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

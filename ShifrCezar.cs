//Программа шифрования/дешифрования символов кирилицы шифром Цезаря
//Подключение библиотек
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShifrCezar
{
    class Program
    {
        static void Main()
        {
            //Цикл для повтора задачи
            do
            {
                string path = @"C:\Education\Term 4\KM\ShifrCezar\ShifrCezar\in.txt";
                //Переменная выбора шифрования/дешифрования
                uint k = 0;
                //Строка, к которой применяется шифрованияе/дешифрование
                string s = "";
                //Строка - результат шифрования/дешифрования
                string result = "";
                //Величина сдвига при шифровании/дешифровании
                uint shift;
                //Вывод сообщения на экран
                Console.WriteLine("1 to crypt, 2- decrypt");
                //Считывание переменной выбора, пока она не станет равной 1 или 2
                while ((k != 1) && (k != 2))
                {
                    //Считывание переменной k, если введенные данные имеют тип uint
                    uint.TryParse(Console.ReadLine(), out k);
                    //Вывод сообщения об ошибке, если k != 1 или k != 2
                    if ((k != 1) && (k != 2))
                        Console.WriteLine("Input mistake");
                }
                //Вывод сообщения на экран
                Console.WriteLine("input shift amount");
                //Считывние величины сдвига
                while (!uint.TryParse(Console.ReadLine(), out shift))
                {
                    //Если введена неверная величина сдвига (отрицательное число, или не число)
                    Console.WriteLine("Input mistake");
                }
                //Если величина сдвига больше длины алфавита кирилицы
                if (shift > 32)
                    shift = shift % 32;
                //Если выбрано шифрование
                if (k == 1)
                {
                    //Вывод сообщения на экран
                    Console.WriteLine("String reading drom file!");
                    //Считывание строки
                    s = File.ReadAllText(path, Encoding.Default);
                    //Выполение шифрования
                    //Цикл по каждому символу строки
                    for (int i = 0; i < s.Length; i++)
                    {
                        //Если не кириллица
                        if (((int)(s[i]) < 1040) || ((int)(s[i]) > 1103))
                            result += s[i];
                        //Если буква является строчной
                        if ((Convert.ToInt16(s[i]) >= 1072) && (Convert.ToInt16(s[i]) <= 1103))
                        {
                            //Если буква, после сдвига выходит за пределы алфавита
                            if (Convert.ToInt16(s[i]) + shift > 1103)
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(s[i]) + shift - 32);
                            //Если буква может быть сдвинута в пределах алфавита
                            else
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(s[i]) + shift);
                        }
                        //Если буква является прописной
                        if ((Convert.ToInt16(s[i]) >= 1040) && (Convert.ToInt16(s[i]) <= 1071))
                        {
                            //Если буква, после сдвига выходит за пределы алфавита
                            if (Convert.ToInt16(s[i]) + shift > 1071)
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(s[i]) + shift - 32);
                            //Если буква может быть сдвинута в пределах алфавита
                            else
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(s[i]) + shift);
                        }
                    }
                    //Вывод на экран зашифрованной строки
                    Console.WriteLine("String successfully crypt!");
                    StreamWriter sr = new StreamWriter(@"C:\Education\Term 4\KM\ShifrCezar\ShifrCezar\cryprt.txt", false);
                    sr.Write(result);
                    sr.Close();
                    Console.WriteLine(result);
                }
                //Если было выбрано дешифрование
                if (k == 2)
                {
                    //Вывод сообщения на экран
                    Console.WriteLine("String reading from file!");
                    //Считывание строки
                    //s = File.ReadAllText(path, Encoding.Default);- не читает если есть Encoding.Default
                    StreamReader sr = new StreamReader(@"C:\Education\Term 4\KM\ShifrCezar\ShifrCezar\in.txt");
                    s = sr.ReadToEnd();
                    sr.Close();
                    //Time.Start();- вообще не нужно!
                    //Выполение дешифрования
                    //Цикл по каждому символу строки
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (Convert.ToInt16(s[i]) == 32)
                            result += ' ';
                        //Если буква является строчной
                        if ((Convert.ToInt16(s[i]) >= 1072) && (Convert.ToInt16(s[i]) <= 1103))
                        {
                            //Если буква, после сдвига выходит за пределы алфавита
                            if (Convert.ToInt16(s[i]) - shift < 1072)
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(s[i]) - shift + 32);
                            //Если буква может быть сдвинута в пределах алфавита
                            else
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(s[i]) - shift);
                        }
                        //Если буква является прописной
                        if ((Convert.ToInt16(s[i]) >= 1040) && (Convert.ToInt16(s[i]) <= 1071))
                        {
                            //Если буква, после сдвига выходит за пределы алфавита
                            if (Convert.ToInt16(s[i]) - shift < 1040)
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(s[i]) - shift + 32);
                            //Если буква может быть сдвинута в пределах алфавита
                            else
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(s[i]) - shift);
                        }
                    }
                    //Вывод на экран дешифрованной строки
                    Console.WriteLine("String successfulle decrypt!");
                    StreamWriter sr1 = new StreamWriter(@"C:\Education\Term 4\KM\ShifrCezar\ShifrCezar\decrypt.txt", false);
                    sr1.Write(result);
                    sr1.Close();
                    Console.WriteLine(result);
                }
                Console.WriteLine("To Exit input Escape");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

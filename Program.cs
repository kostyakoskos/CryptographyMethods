using System;
using System.IO;
using System.Text;

namespace ShifrVizenera
{
    class Program
    {
        static void Main(string[] args)
        {
            //making vigener table
            int lenStr = 32, lenColumn = 32, countI = 1072, myCounter = 0;
            string key = "", input = "", result = "", decrypt = "", resDecrypt = "";
            char[,] letters = new char[lenStr, lenColumn];
            for (int i = 0; i < lenStr; i++)
            {
                for (int j = 0; j < lenColumn; j++)
                {
                    if (countI + j <= 1103)
                    {
                        letters[i, j] = Convert.ToChar(countI + j);
                    }
                    else
                    {
                        letters[i, j] = Convert.ToChar(countI + j - 32);
                    }
                }
                countI++;
            }

            using (TextReader reader = new StreamReader(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrVizenera\\key.txt", Encoding.Default))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    key = str;
                }
            }

            //decrypt
            using (TextReader reader = new StreamReader(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrVizenera\\in.txt", Encoding.Default))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    input = str;
                }
            }

            char[] arr = new char[input.Length];
            arr = input.ToCharArray();
            char[] arrKey = new char[key.Length];
            arrKey = key.ToCharArray();
            for (int l = 1; l <= arr.Length; l++)
            {
                for (int i = 0; i < lenStr; i++)
                {
                    if (String.Equals(letters[i, 0], arrKey[myCounter % l]))// find keyword letter
                    {
                        for (int j = 0; j < lenColumn; j++)// cycle in column
                        {
                            if (String.Equals(letters[i, j], arr[l - 1]))
                            {
                                result += letters[0, j - 1];
                                if (myCounter == arrKey.Length - 1)
                                    myCounter = 0;
                                else myCounter++;
                                i = lenStr;
                                j = lenColumn;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("String successfully decrypt!");
            StreamWriter sr = new StreamWriter(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrVizenera\\decrypt.txt", false);
            sr.Write(result);
            sr.Close();

            //crypt
            using (TextReader reader = new StreamReader(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrVizenera\\decrypt.txt", Encoding.Default))
            {
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    decrypt = str;
                }
            }

            char[] crypt = new char[decrypt.Length];
            crypt = decrypt.ToCharArray();

            myCounter = 0;

            for (int l = 1; l <= crypt.Length; l++)// cyclr for every letter of decrypt string
            {
                for (int i = 0; i < lenStr; i++)// cecle for find key letter
                {
                    if (String.Equals(letters[i, 0], arrKey[myCounter % l]))
                    {
                        for (int j = 0; j < lenColumn; j++)// cycle for find descrypt word letter
                        {
                            if(String.Equals(letters[j,0], crypt[l - 1]))
                            {
                                resDecrypt += letters[i, j + 1];
                                if (myCounter == arrKey.Length - 1)
                                    myCounter = 0;
                                else myCounter++;
                                i = lenColumn;
                                j = lenStr;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("String successfully crypt!");
            StreamWriter sr1 = new StreamWriter(@"C:\\Education\\Term 4\\KM\\ShifrCezar\\ShifrVizenera\\crypt.txt", false);
            sr1.Write(resDecrypt);
            sr1.Close();
        }
    }
}

namespace OcurrencesOfWordsInTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class OcurrencesOfWordsInTextFile
    {
        private const string FILE_SRC_STRING = @"..\..\words.txt";
        static void Main()
        {
            var reader = new StreamReader(FILE_SRC_STRING);
            var stringBuild = new StringBuilder();

            using (reader)
            {
                while (reader.Peek() >= 0)
                {
                    stringBuild.Append(reader.ReadLine());
                }
            }

            var allTextFromTheFile = stringBuild.ToString();
            allTextFromTheFile = allTextFromTheFile.ToLower();

            var words = allTextFromTheFile.Split(new char[] { ',', ' ', '-', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            var dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = 0;
                }
                dictionary[word]++;
            }

            foreach (var entry in dictionary)
            {
                Console.WriteLine("{0} --> {1} times", entry.Key, entry.Value);
            }
        }
    }
}

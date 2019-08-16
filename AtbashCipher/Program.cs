using System;

namespace AtbashCipher
{
    class AtbashCipher
    {
        //alphabets
        const string RUalphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        const string ENalphabet = "abcdefghijklmnopqrstuvwxyz";
        public string alphabet;

        //method for flipping a string
        private string Flipping(string inputText)
        {
            //variable to store the result
            var flippedText = string.Empty;
            foreach (var s in inputText)
            {
                //add a character to the beginning of the line
                flippedText = s + flippedText;
            }
            return flippedText;
        }

        //encryption/decryption method
        private string EncryptDecrypt(string text, string symbols, string cipher)
        {
            //translate text to lowercase
            text = text.ToLower();

            var outputText = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                //search for a character position in an alphabet string
                var index = symbols.IndexOf(text[i]);
                if (index >= 0)
                {
                    //change character to cipher
                    outputText += cipher[index].ToString();
                }
            }
            return outputText;
        }

        //text encryption
        public string EncryptMessage(string language, string plainText)
        {
            if (language == "RU")
            {
                alphabet = RUalphabet;
            }
            else if (language == "EN")
            {
                alphabet = ENalphabet;
            }
            return EncryptDecrypt(plainText, alphabet, Flipping(alphabet));
        }

        //text decryption
        public string DecryptMessage(string language, string encryptedText)
        {
            if (language == "RU")
            {
                alphabet = RUalphabet;
            }
            else if (language == "EN")
            {
                alphabet = ENalphabet;
            }
            return EncryptDecrypt(encryptedText, Flipping(alphabet), alphabet);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Atbash encryption");
            var atbash = new AtbashCipher();
            string language;
            while (true)
            {
                Console.Write("Enter the required language (\"RU\" or \"EN\"): ");
                var answer = Console.ReadLine();
                if (answer == "RU")
                {
                    language = "RU";
                    break;
                }
                else if (answer == "EN")
                {
                    language = "EN";
                    break;
                }
            }
            Console.Write("Enter text: ");
            var message = Console.ReadLine();
            var encryptedMessage = atbash.EncryptMessage(language, message);
            Console.WriteLine("Encrypted message: {0}", encryptedMessage);
            var decryptedMessage = atbash.DecryptMessage(language, encryptedMessage);
            Console.WriteLine("Decrypted message: {0}", decryptedMessage);
            Console.ReadLine();
        }
    }
}

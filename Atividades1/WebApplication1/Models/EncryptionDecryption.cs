using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Models
{
    public class EncryptionDecryption
    {
        public string? userInput { get; set; }
        public int shift { get; set; }
        public string? encryptedText { get; set; }
        public string? decryptedText { get; set; }

        public string Encrypt(string userInput, int shift)
        {
            string encryptedText = "";

            foreach (char c in userInput)
            {
                if (char.IsLetter(c))
                {
                    char lowerC = char.ToLower(c);
                    char shifted = (char)(((lowerC + shift - 'a') % 26) + 'a');
                    encryptedText += shifted;
                }

                else
                {
                    encryptedText += c;
                }
            }

            return encryptedText;
        }

        public string Decrypt(string encryptedText, int shift)
        {
            string userInput = "";

            foreach (char c in encryptedText)
            {
                if (char.IsLetter(c))
                {
                    char lowerC = char.ToLower(c);
                    char shifted = (char)(((lowerC - shift - 'a' + 26) % 26) + 'a');
                    userInput += shifted;
                }

                else
                {
                    userInput += c;
                }
            }

            return userInput;
        }
    }
}
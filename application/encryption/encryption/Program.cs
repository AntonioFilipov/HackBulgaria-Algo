using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder first = new StringBuilder();
            StringBuilder second = new StringBuilder();
            StringBuilder result = new StringBuilder();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
			{
			    if (i < input.Length/2)
	            {
                    first.Append(input[i]);
	            }
                else
                {
                    second.Append(input[i]);
                }
			}
            result.Append(second);
            result.Append(first);


            List<string> splittedItems = new List<string>();
            splittedItems = result.ToString().Split('~').ToList();
            int alphabetLength = int.Parse(splittedItems[0]);
            string text = splittedItems[1]; 
            int keyLength = int.Parse(splittedItems[2]);
            string alphabet = text.Substring(0,alphabetLength);
            string encryptedMessage = text.Substring(alphabetLength, text.Length - alphabetLength - keyLength);
            string key = text.Substring(alphabetLength + encryptedMessage.Length);

            List<int> indicesEncryptedMessage = new List<int>();
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (encryptedMessage[i] == alphabet[j])
                    {
                        indicesEncryptedMessage.Add(j);
                    }
                }
            }
            //Console.WriteLine(alphabet);
            //Console.WriteLine(encryptedMessage);
            //Console.WriteLine(key);

            //Console.WriteLine(string.Join(",", indicesEncryptedMessage));

            for (int i = 0; i < indicesEncryptedMessage.Count; i++)
            {
                indicesEncryptedMessage[i] += alphabetLength;
            }
            //Console.WriteLine(string.Join(",", indicesEncryptedMessage));
            
            StringBuilder repeatedKey = new StringBuilder();

            int decryptedMessageLength = encryptedMessage.Length;

            for (int i = 0, p=0; i < decryptedMessageLength; i++)
            {                
                if (p == key.Length)
                {
                    p = 0;
                }
                repeatedKey.Append(key[p]);
                p++;

            }
            //Console.WriteLine(repeatedKey.ToString());


            List<int> indicesKey = new List<int>();
            for (int i = 0; i < repeatedKey.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (repeatedKey[i] == alphabet[j])
                    {
                        indicesKey.Add(j);
                    }
                }
            }
            //Console.WriteLine(string.Join(",", indicesKey));

            List<int> messageKey = new List<int>();
            for (int i = 0; i < indicesKey.Count; i++)
            {
                messageKey.Add(indicesEncryptedMessage[i] - indicesKey[i]);
                if (messageKey[i] >= alphabetLength)
                {
                    messageKey[i] -= alphabetLength;
                }
            }
            //Console.WriteLine(string.Join(",", messageKey));

            StringBuilder message = new StringBuilder();
            for (int i = 0; i < messageKey.Count; i++)
            {
                message.Append(alphabet[messageKey[i]]);
            }
            Console.WriteLine(message.ToString());            
        }
    }
}

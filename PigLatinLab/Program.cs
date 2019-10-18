using System;

namespace PigLatinLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string[] theWords;
            
            Console.WriteLine("Welcome to the Pig Latin-ifier!!");

            Console.Write("Enter a word or phrase to translate INTO Pig Latin: ");
            userInput = Console.ReadLine();
            theWords = userInput.Split();

            for (int x = 0; x < theWords.Length; x++) 
            {
                //check to see if the word has a puncuation mark attached to it
                if(theWords[x].EndsWith('!')|| theWords[x].EndsWith('?')|| theWords[x].EndsWith('.')|| theWords[x].EndsWith(','))
                {
                    //grab the piece of puncuation and store it for later
                    string puncuation = theWords[x].Substring(theWords[x].Length-1);

                    //get rid of the puncuation
                    theWords[x] = theWords[x].Substring(0, theWords[x].Length-1);

                    //PigLatinify the Word
                    theWords[x] = PigLatinify(theWords[x]);

                    //add the puncuation back on
                    theWords[x] = theWords[x] + puncuation;
                    continue;
                }

                //Check to see if the word is a contraction
                if (theWords[x].Contains('\''))
                {
                    theWords[x] = PigLatinify(theWords[x]);
                }

                //check to see if the word has non-letter characters, and don't PigLatinify it
                else if (ContainsStrangeCharacter(theWords[x]) == true)
                {
                    continue;
                }

                //PigLatinify the word
                else
                {
                    theWords[x] = PigLatinify(theWords[x]);
                }
            }

            //Print out the PigLatinified words
            foreach(string word in theWords)
            {
                Console.Write($"{word} ");
            }

        }

        //Translate the word into pig latin.
        public static string PigLatinify(string word)
        {
            //send the incoming word to a string array
            char[] wordArray = word.ToCharArray();

            //check to see if the first letter is a vowel
            if(IsVowel(wordArray[0]))
            {
                return word + "way";
            } 
            
            else
            {
                //variable to track the index of the first vowel in the word
                int firstVowel = 0;

                //string to hold the consenants before the first vowel
                string firstConsenants;


                for(int x = 0; x < wordArray.Length; x++)
                {
                    //Check to see if the letter in question is a vowel
                    if (IsVowel(wordArray[x]))
                    {
                        //save the index of the first vowel and break the loops
                        firstVowel = x;
                        break;
                    }
                }
                //Get the consenants before the vowel
                firstConsenants = word.Substring(0, firstVowel);

                //remove the first consenants, append them at the end and add "ay"
                word = word.Substring(firstVowel) + firstConsenants + "ay";
                return word;
            }
        }

        //Method to check to see if a given letter is a vowel
        public static bool IsVowel(char c)
        {
            string check = c.ToString();
            check.ToLower();
 
            if (check == "a" || check == "e" || check == "i" || check == "o" || check == "u")
            {
                return true;
            }
            return false;
        }
        
        //Method to see if the word contains a character that is NOT a letter
        public static bool ContainsStrangeCharacter(string word)
        {
            foreach (char c in word)
            {
                if (!char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

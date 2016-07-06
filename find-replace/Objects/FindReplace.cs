using Nancy;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FindReplace.Objects
{
  public class Phrase
  {
    public string CustomReplace(string startPhrase, string wordToReplace, string newWord, bool IsCaseSensitive, bool PartialMatches)
    {
      string[] finalReplacedArray = Regex.Split(startPhrase," ");
      List<string> finalWords = new List<string> {};
      foreach (string word in finalReplacedArray)
      {
        string firstletter = word.Substring(0,1);
        string splitWord = word.Substring(1);
        finalWords.Add(firstletter + splitWord.ToLower());
      }
      string inputPhrase = string.Join(" ",finalWords);
      if (IsCaseSensitive)
      {
        return LiteralReplace(inputPhrase, wordToReplace, newWord, PartialMatches);
      }
      else
      {
        string firstReplaceLetter = wordToReplace.Substring(0,1);
        string restOfReplaceWord = wordToReplace.Substring(1);
        string UpperCaseReplaceWord = firstReplaceLetter.ToUpper()+restOfReplaceWord;
        string LowerCaseReplaceWord = firstReplaceLetter.ToLower()+restOfReplaceWord;
        string firstNewLetter = newWord.Substring(0,1);
        string restOfNewWord = newWord.Substring(1);
        string UpperCaseNewWord = firstNewLetter.ToUpper()+restOfNewWord;
        string LowerCaseNewWord = firstNewLetter.ToLower()+restOfNewWord;
        string halfwaythere = LiteralReplace(inputPhrase, UpperCaseReplaceWord, UpperCaseNewWord, PartialMatches);
        return LiteralReplace(halfwaythere, LowerCaseReplaceWord, LowerCaseNewWord, PartialMatches);
      }
    }
    public string LiteralReplace(string inputPhrase, string wordToReplace, string newWord, bool PartialMatches)
    {
      string partialMatched = inputPhrase.Replace(wordToReplace, newWord);
      if (PartialMatches)
      {
        return partialMatched;
      }
      else
      {
        Regex characterInFront = new Regex(@"([a-zA-Z])" + newWord);
        Regex characterInBack = new Regex(newWord + @"([a-zA-Z])");
        string frontReReplaced = characterInFront.Replace(partialMatched, "$1" + wordToReplace);
        string AllReReplaced= characterInBack.Replace(frontReReplaced, wordToReplace + "$1");
        return  AllReReplaced;
      }
    }
  }
}

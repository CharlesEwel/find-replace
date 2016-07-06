using Nancy;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FindReplace.Objects
{
  public class Phrase
  {
    public string CustomReplace(string inputPhrase, string wordToReplace, string newWord, bool IsCaseSensitive, bool PartialMatches)
    {
      if (IsCaseSensitive)
      {
        string partialMatched=inputPhrase.Replace(wordToReplace, newWord);
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
          return AllReReplaced;
        }
      }
      else
      {
        string firstReplaceLetter=wordToReplace.Substring(0,1);
        string restOfReplaceWord=wordToReplace.Substring(1);
        string UpperCaseReplaceWord=firstReplaceLetter.ToUpper()+restOfReplaceWord;
        string LowerCaseReplaceWord=firstReplaceLetter.ToLower()+restOfReplaceWord;
        string firstNewLetter=newWord.Substring(0,1);
        string restOfNewWord=newWord.Substring(1);
        string UpperCaseNewWord=firstNewLetter.ToUpper()+restOfNewWord;
        string LowerCaseNewWord=firstNewLetter.ToLower()+restOfNewWord;
        string UpperCaseReplaced = inputPhrase.Replace(LowerCaseReplaceWord, LowerCaseNewWord);
        string FinalReplaced = UpperCaseReplaced.Replace(UpperCaseReplaceWord, UpperCaseNewWord);
        if (PartialMatches)
        {
          return FinalReplaced;
        }
        else
        {
          Regex upperCharacterInFront = new Regex(@"([a-zA-Z])" + UpperCaseNewWord);
          Regex upperCharacterInBack = new Regex(UpperCaseNewWord + @"([a-zA-Z])");
          Regex lowerCharacterInFront = new Regex(@"([a-zA-Z])" + LowerCaseReplaceWord);
          Regex lowerCharacterInBack = new Regex(LowerCaseReplaceWord + @"([a-zA-Z])");
          string upperFrontReReplaced = upperCharacterInFront.Replace(FinalReplaced, "$1" + UpperCaseReplaceWord);
          string allFrontReReplaced = lowerCharacterInFront.Replace(upperFrontReReplaced, "$1" + LowerCaseReplaceWord);
          string upperBackReReplaced = upperCharacterInBack.Replace(allFrontReReplaced, UpperCaseReplaceWord + "$1");
          string AllReReplaced = lowerCharacterInBack.Replace(upperBackReReplaced, LowerCaseReplaceWord + "$1");
          return AllReReplaced;
        }
      }
    }
  }
}

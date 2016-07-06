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
        Regex caseInsensitiveWord = new Regex(wordToReplace, RegexOptions.IgnoreCase);
        string outputPhrase = caseInsensitiveWord.Replace(inputPhrase, newWord);
        if (PartialMatches)
        {
          return outputPhrase;
        }
        else
        {
          Regex characterInFront = new Regex(@"([a-zA-Z])" + newWord);
          Regex characterInBack = new Regex(newWord + @"([a-zA-Z])");
          string frontReReplaced = characterInFront.Replace(outputPhrase, "$1" + wordToReplace);
          string AllReReplaced = characterInBack.Replace(frontReReplaced, wordToReplace + "$1");
          return AllReReplaced;
        }
      }
    }
  }
}

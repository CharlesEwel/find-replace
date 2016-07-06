using Nancy;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FindReplace.Objects
{
  public class Phrase
  {
    public string CustomReplace(string inputPhrase, string wordToReplace, string newWord, bool IsCaseSensitive)
    {
      if (IsCaseSensitive)
      {
        return inputPhrase.Replace(wordToReplace, newWord);
      }
      else
      {
        Regex caseInsensitiveWord = new Regex(wordToReplace, RegexOptions.IgnoreCase);
        string outputPhrase = caseInsensitiveWord.Replace(inputPhrase, newWord);
        return outputPhrase;
      }
    }
  }
}

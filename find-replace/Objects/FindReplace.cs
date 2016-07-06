using Nancy;
using System;
using System.Collections.Generic;

namespace FindReplace.Objects
{
  public class Phrase
  {
    public string CustomReplace(string inputPhrase, string wordToReplace, string newWord)
    {
      return inputPhrase.Replace(wordToReplace, newWord);
    }
  }
}

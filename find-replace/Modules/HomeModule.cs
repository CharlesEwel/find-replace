using Nancy;
using System;
using FindReplace.Objects;
using System.Collections.Generic;

namespace FindReplace
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Post["/new-phrase"] = _ => {
        Phrase newPhrase = new Phrase ();
        string resultPhrase = newPhrase.CustomReplace(Request.Form["phrase-input"], Request.Form["word-replace"], Request.Form["new-word"], Request.Form["case-sensitivity"]);
        return View["index.cshtml", resultPhrase];
      };
    }
  }
}

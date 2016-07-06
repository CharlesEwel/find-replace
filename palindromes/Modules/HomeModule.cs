using Nancy;
using System;
using Palindrome.Objects;
using System.Collections.Generic;

namespace Palindrome
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
    }
  }
}

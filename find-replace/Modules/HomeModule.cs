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
    }
  }
}

using Xunit;
namespace FindReplace.Objects
{
  public class FindReplaceTest
  {
    [Fact]
    public void CustomReplace_OneWord_1()
    {
      Phrase newPhrase = new Phrase ();
      Assert.Equal("Hello universe", newPhrase.CustomReplace("Hello world", "world", "universe"));
    }
  }
}

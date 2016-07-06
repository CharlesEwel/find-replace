using Xunit;
namespace Palindrome.Objects
{
  public class PalindromeTest
  {
    [Fact]
    public void CustomReplace_OneWord_Replaces()
    {
      Phrase newPhrase = new Phrase ();
      Assert.Equal("Hello universe", newPhrase.CustomReplace("Hello world", "world", "universe", true, true));
    }
  }
}

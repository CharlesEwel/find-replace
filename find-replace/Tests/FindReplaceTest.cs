using Xunit;
namespace FindReplace.Objects
{
  public class FindReplaceTest
  {
    [Fact]
    public void CustomReplace_OneWord_Replaces()
    {
      Phrase newPhrase = new Phrase ();
      Assert.Equal("Hello universe", newPhrase.CustomReplace("Hello world", "world", "universe", true, true));
    }
    [Fact]
    public void CustomReplace_CaseInsensitive_Replaces()
    {
      Phrase newPhrase = new Phrase ();
      Assert.Equal("Hello universe", newPhrase.CustomReplace("Hello World", "world", "universe", false, false));
    }
    [Fact]
    public void CustomReplace_FullWord_Replaces()
    {
      Phrase newPhrase = new Phrase ();
      Assert.Equal("The dog in the cathedral", newPhrase.CustomReplace("The cat in the cathedral", "cat", "dog", true, false));
    }
    [Fact]
    public void CustomReplace_FullWordNew_Replaces()
    {
      Phrase newPhrase = new Phrase ();
      Assert.Equal("The dog in the cathedral", newPhrase.CustomReplace("The Cat in the cathedral", "cat", "dog", false, false));
    }
  }
}

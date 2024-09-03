using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PastebinTaskOne;

namespace WebTests
{
	public class PastebinMainPageTests : IDisposable
	{
		public IWebDriver Browser { get; set; }
		
		public PastebinMainPageTests()
        {
			Browser = new ChromeDriver();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			Browser.Quit();
		}

		[Fact]
		public void CreatePaste_FillTextAndExpiration_TaskOne()
		{
			var page = new PastebinMainPage(Browser);
			page.Navigate();

			page.PasteText("Hello from WebDriver");
			page.SelectPasteExpiration("10 Minutes");
			page.Submit();
			Assert.True(true);
		}

		[Fact]
		public void CreatePaste_FillTextHighlightExpiration_Verify_TaskTwo()
		{
			var page = new PastebinMainPage(Browser);
			page.Navigate();

			string expectedTextPaste = 
				"git config --global user.name  \"New Sheriff in Town\"\n" +
				"git reset $(git commit-tree HEAD^{tree} -m \"Legacy code\")\n" +
				"git push origin master --force";
			string expectedSyntaxHighlight = "Bash";
			string expectedPasteExpiration = "10 Minutes";
			page.PasteText(expectedTextPaste);
			page.SelectSyntaxHighlight(expectedSyntaxHighlight);
			page.SelectPasteExpiration(expectedPasteExpiration);
			page.Submit();

			var pastePage = new PastebinPastePage(Browser);
			var actualText = pastePage.GetElementText(pastePage.Map.TextLinesPaste);
			var syntax = pastePage.GetElementText(pastePage.Map.SyntaxHighlight);
			var expiration = pastePage.GetElementText(pastePage.Map.Expire);

			Assert.Equal(expectedTextPaste, actualText);
			Assert.Equal(expectedSyntaxHighlight, syntax);
			Assert.Equal(expectedPasteExpiration, expiration);
		}

	}
}
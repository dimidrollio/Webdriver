using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PastebinTaskOne
{
	public class PastebinMainPageMap
	{
		private readonly IWebDriver _browser;
		public IWebElement PasteSyntaxHighlight => _browser.FindElement(By.Id("select2-postform-format-container"));

		public IWebElement PasteTextField => _browser.FindElement(By.Id("postform-text"));
		public IWebElement PasteExpirationDropdown => _browser.FindElement(By.XPath("//*[@id=\"select2-postform-expiration-container\"]"));
		public IWebElement PasteSubmitButton => _browser.FindElement(By.XPath("//button[@class=\"btn -big\"]"));
		public PastebinMainPageMap(IWebDriver browser)
        {
            _browser = browser;
        }
		public IWebElement GetDropdownObject(string obj) => _browser.FindElement(By.XPath($"//ul[@role =\"listbox\"]//li[text() = '{obj}']"));
	}
}

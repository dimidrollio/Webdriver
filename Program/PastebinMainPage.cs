using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.Page;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebinTaskOne
{
	public class PastebinMainPage
	{
		private readonly IWebDriver _browser;
		private readonly string _url = "https://pastebin.com/";

		public PastebinMainPageMap Map => new(_browser);

        public PastebinMainPage(IWebDriver browser)
        {
			_browser = browser;
        }
        public void Navigate()
		{
			_browser.Navigate().GoToUrl(_url);
		}

		public void SelectPasteExpiration(string toSelect)
		{
			var waiter = new WebDriverWait(_browser, TimeSpan.FromSeconds(5));
			waiter.Until(x => Map.PasteExpirationDropdown.Enabled && Map.PasteExpirationDropdown.Displayed);
			Map.PasteExpirationDropdown.Click();

			var expirationObject = Map.GetDropdownObject(toSelect);
			waiter.Until(obj => expirationObject.Displayed && expirationObject.Enabled);

			expirationObject.Click();
		}

		public void SelectSyntaxHighlight(string toSelect)
		{
			var waiter = new WebDriverWait(_browser, TimeSpan.FromSeconds(5));
			waiter.Until(x => Map.PasteSyntaxHighlight.Enabled);

			Map.PasteSyntaxHighlight.Click();

			var syntaxHighlightObject = Map.GetDropdownObject(toSelect);

			waiter.Until(obj =>  syntaxHighlightObject.Displayed && syntaxHighlightObject.Enabled);
			syntaxHighlightObject.Click();
		}

		public void PasteText(string text)
		{
			var waiter = new WebDriverWait(_browser, TimeSpan.FromSeconds(5));
			waiter.Until(x => Map.PasteTextField.Enabled && Map.PasteTextField.Displayed);

			Map.PasteTextField.SendKeys(text);			
		}

		public void Submit()
		{
			var waiter = new WebDriverWait(_browser, TimeSpan.FromSeconds(5));
			waiter.Until(x => Map.PasteSubmitButton.Enabled && Map.PasteSubmitButton.Displayed);

			Map.PasteSubmitButton.Click();
		}
    }
}

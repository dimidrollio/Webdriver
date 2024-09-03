using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebinTaskOne
{
	public class PastebinPastePageMap
	{
		private readonly IWebDriver _browser;
		public IWebElement Title => _browser.FindElement(By.XPath("//div[@class ='info-top']//h1"));
		public IEnumerable<IWebElement> TextLinesPaste => _browser.FindElements(By.XPath("//ol/li/div"));
		public IWebElement SyntaxHighlight => _browser.FindElement(By.XPath("//div[@class='left']/a[contains(@href, '/archive/')]"));
		public IWebElement Expire => _browser.FindElement(By.XPath("//div[@class = 'info-bottom']//div[@class = 'expire']"));
			
        public PastebinPastePageMap(IWebDriver browser)
        {
			_browser = browser;
        }
    }
}

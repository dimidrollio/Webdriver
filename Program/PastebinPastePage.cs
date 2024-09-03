using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebinTaskOne
{
	public class PastebinPastePage
	{
        public PastebinPastePage(IWebDriver browser)
        {
            _browser = browser;
        }
        private readonly IWebDriver _browser;
		public PastebinPastePageMap Map => new(_browser);
		public string GetElementText(IWebElement webElement)
		{
			return webElement.Text.Trim('\n', 'r');
		}
		public string GetElementText(IEnumerable<IWebElement> webElements)
		{
			StringBuilder resultString = new StringBuilder();
			foreach (var webElement in webElements)
			{
				resultString.AppendLine( GetElementText(webElement));
			}

			return resultString.ToString();
		}
	}
}

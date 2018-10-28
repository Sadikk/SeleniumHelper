using OpenQA.Selenium;
using System;

namespace TwitterMaster.Core.Selenium.Drivers
{
	public interface IAdvancedWebDriver : IWebDriver, ISearchContext, IDisposable
	{
		string ParentWindowHandler
		{
			get;
			set;
		}

		IWebElement FindElementByClassName(string className);

		IWebElement FindElementByCssSelector(string cssSelector);

		IWebElement FindElementById(string id);

		IWebElement FindElementByName(string name);

		IWebElement FindElementByXPath(string path);
	}
}
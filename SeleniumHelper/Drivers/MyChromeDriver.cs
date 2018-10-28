using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Runtime.CompilerServices;

namespace TwitterMaster.Core.Selenium.Drivers
{
	public class MyChromeDriver : ChromeDriver, IAdvancedWebDriver, IWebDriver, ISearchContext, IDisposable
	{
		public string ParentWindowHandler
		{
			get;
			set;
		}

		public MyChromeDriver()
		{
		}

		public MyChromeDriver(ChromeOptions options) : base(options)
		{
		}
	}
}
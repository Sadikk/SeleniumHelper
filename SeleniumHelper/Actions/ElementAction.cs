using TwitterMaster.Core.Selenium.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.CompilerServices;

namespace TwitterMaster.Core.Selenium.Actions
{
	public class ElementAction
	{
		public string Clue
		{
			get;
			private set;
		}

		public IAdvancedWebDriver Driver
		{
			get;
			set;
		}

		public ElementClueEnum Type
		{
			get;
			private set;
		}

		public bool WaitBefore
		{
			get;
			private set;
		}

		public ElementAction(IAdvancedWebDriver driver, string clue, ElementClueEnum type, bool wait = false)
		{
			this.WaitBefore = wait;
			this.Clue = clue;
			this.Type = type;
			this.Driver = driver;
		}

		public virtual void Perform(int timeout = 5)
		{
			if (this.Wait(timeout))
			{
                IWebElement element = null;
                switch (this.Type)
                {
                    case ElementClueEnum.Id:
                        {
                            element = this.Driver.FindElementById(this.Clue);

                            break;
                        }
                    case ElementClueEnum.ClassName:
                        {
                            element = this.Driver.FindElementByClassName(this.Clue);
                            break;
                        }
                    case ElementClueEnum.XPath:
                        {
                            element = Driver.FindElementByXPath(this.Clue);
                            break;
                        }
                    case ElementClueEnum.Name:
                        {
                            element = Driver.FindElementByName(this.Clue);
                            break;
                        }
                    case ElementClueEnum.CssSelector:
                        {
                            element = Driver.FindElementByCssSelector(this.Clue);
                            break;
                        }
                    case ElementClueEnum.Text:
                        {
                            element = Driver.FindElement(By.LinkText(this.Clue));
                            break;
                        }
                    case ElementClueEnum.PartialText:
                        {
                            element = Driver.FindElement(By.PartialLinkText(this.Clue));
                            break;
                        }
                }
                if (element != null)
                {

                    try
                    {
                        element.Click();
                    }
                    catch (InvalidOperationException)
                    {
                        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                        element.Click();
                    }
                }
            }
		}

		public bool Wait(int timeout = 5)
		{
			bool flag;
			try
			{
				switch (this.Type)
				{
					case ElementClueEnum.Id:
					{
						(new WebDriverWait(this.Driver, TimeSpan.FromSeconds((double)timeout))).Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.Id(this.Clue)));
						break;
					}
					case ElementClueEnum.ClassName:
					{
						(new WebDriverWait(this.Driver, TimeSpan.FromSeconds((double)timeout))).Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.ClassName(this.Clue)));
						break;
					}
					case ElementClueEnum.XPath:
					{
						(new WebDriverWait(this.Driver, TimeSpan.FromSeconds((double)timeout))).Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.XPath(this.Clue)));
						break;
					}
					case ElementClueEnum.Name:
					{
						(new WebDriverWait(this.Driver, TimeSpan.FromSeconds((double)timeout))).Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.Name(this.Clue)));
						break;
					}
					case ElementClueEnum.CssSelector:
					{
						(new WebDriverWait(this.Driver, TimeSpan.FromSeconds((double)timeout))).Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.CssSelector(this.Clue)));
						break;
					}
                    case ElementClueEnum.Text:
                        (new WebDriverWait(this.Driver, TimeSpan.FromSeconds((double)timeout))).Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.LinkText(this.Clue)));
                        break;
                    case ElementClueEnum.PartialText:
                        (new WebDriverWait(this.Driver, TimeSpan.FromSeconds((double)timeout))).Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(this.Clue)));
                        break;
				}
				flag = true;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}
	}
}
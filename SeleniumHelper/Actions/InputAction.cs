using TwitterMaster.Core.Selenium.Drivers;
using OpenQA.Selenium;
using System;
using System.Runtime.CompilerServices;

namespace TwitterMaster.Core.Selenium.Actions
{
    public class InputAction : ElementAction
    {
        public string Text
        {
            get;
            private set;
        }

        public InputAction(IAdvancedWebDriver driver, string clue, ElementClueEnum type, string text, bool wait = false) : base(driver, clue, type, wait)
        {
            this.Text = text;
        }

        public override void Perform(int timeout = 10)
        {
            if (base.Wait(timeout))
            {
                switch (base.Type)
                {
                    case ElementClueEnum.Id:
                        {
                            base.Driver.FindElementById(base.Clue).SendKeys(this.Text);
                            break;
                        }
                    case ElementClueEnum.ClassName:
                        {
                            base.Driver.FindElementByClassName(base.Clue).SendKeys(this.Text);
                            break;
                        }
                    case ElementClueEnum.XPath:
                        {
                            base.Driver.FindElementByXPath(base.Clue).SendKeys(this.Text);
                            break;
                        }
                    case ElementClueEnum.Name:
                        {
                            base.Driver.FindElementByName(base.Clue).SendKeys(this.Text);
                            break;
                        }
                    case ElementClueEnum.CssSelector:
                        {
                            base.Driver.FindElementByCssSelector(base.Clue).SendKeys(this.Text);
                            break;
                        }
                    case ElementClueEnum.Text:
                        {
                            base.Driver.FindElement(By.LinkText(base.Clue)).SendKeys(this.Text);
                            break;
                        }
                    case ElementClueEnum.PartialText:
                        {
                            base.Driver.FindElement(By.PartialLinkText(base.Clue)).SendKeys(this.Text);
                            break;
                        }
                }
            }
        }
    }
}
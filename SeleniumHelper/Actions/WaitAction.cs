using TwitterMaster.Core.Selenium.Drivers;
using System;

namespace TwitterMaster.Core.Selenium.Actions
{
	public class WaitAction : ElementAction
	{
		public WaitAction(IAdvancedWebDriver driver, string clue, ElementClueEnum type, bool wait = false) : base(driver, clue, type, wait)
		{
		}

		public override void Perform(int timeout = 10)
		{
			base.Wait(timeout);
		}
	}
}
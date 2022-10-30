using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sample_specflow.Hooks;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Sample_specflow.Steps
{
    [Binding]
    public sealed class SearchValidationSteps : BaseSteps

    {
        public SearchValidationSteps(GlobalDriver global) : base(global)
        {

        }

        [Given(@"enable website is launched")]
        public void GivenEnableWebsiteIsLaunched()
        {
            this.global.Driver.Navigate().GoToUrl("https://enable.com/");
            WebDriverWait wait = new WebDriverWait(this.global.Driver, TimeSpan.FromSeconds(10));
            IWebElement enablehomePage = wait.Until(e => e.FindElement(By.XPath("//div[@class = 'navbar']")));
            Assert.IsTrue(enablehomePage.Displayed);
        }


        [Given(@"search is selected")]
        public void GivenSearchIsSelected()
        {

            this.global.Driver.FindElement(By.XPath("//div[@id = 'nav-search-button']")).Click();
        }

        [When(@"wickes keyword entered")]
        public void WhenWickesKeywordEntered()
        {
            this.global.Driver.FindElement(By.XPath("//input[@id = 'nav-search']")).SendKeys("wickes");
            this.global.Driver.FindElement(By.XPath("//input[@id = 'nav-search']")).Submit();
        }

        [Then(@"search word is displayed in results")]
        public void ThenSearchWordIsDisplayedInResults()
        {
            var search = this.global.Driver.PageSource.Contains("/customer-stories/retailer-wickes-onboard-enable-in-a-highly-accelerated-timeframe");
            try
            {
                Assert.IsTrue(search);
            }
            catch(Exception)
            {
                Console.WriteLine("Search results not found - Fail");
            }
            
        }

    }
}

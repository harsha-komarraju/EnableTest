using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sample_specflow.Hooks;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Sample_specflow.Steps
{
    [Binding]
    public sealed class LoginSaucelabsSteps : BaseSteps

    {
        public LoginSaucelabsSteps(GlobalDriver global) : base(global)
        {

        }


        [Given(@"open the Saucedemo website")]
        public void GivenOpenTheSaucedemoWebsite()
        {
            this.global.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"login with username and password")]
        public void WhenLoginWithUsernameAndPassword()
        {
            this.global.Driver.FindElement(By.XPath("//input[@id = 'user-name']")).SendKeys("standard_user");
            this.global.Driver.FindElement(By.XPath("//input[@id = 'password']")).SendKeys("secret_sauce");
        }

        [Then(@"home screen is displayed")]
        public void ThenHomeScreenIsDisplayed()
        {
            this.global.Driver.FindElement(By.XPath("//input[@id = 'login-button']")).Click();

        }


        [Given(@"home page is displayed")]
        public void GivenHomePageIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(this.global.Driver, TimeSpan.FromSeconds(10));
            IWebElement homePage = wait.Until(e => e.FindElement(By.XPath("//div[@id='inventory_container']")));
            Assert.IsTrue(homePage.Displayed);
            Console.WriteLine(homePage.Text);
        }

        [Given(@"sort the list low to high")]
        public void GivenSortTheListLowToHigh()
        {
            WebElement staticDropdown = (WebElement)this.global.Driver.FindElement(By.XPath("//select[@data-test = 'product_sort_container']"));
            SelectElement SelectElement = new SelectElement(staticDropdown);
            SelectElement.SelectByValue("lohi");

        }



        [When(@"first item added to basket")]
        public void WhenFirstItemAddedToBasket()
        {
            this.global.Driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-onesie']")).Click();           
        }


        [When(@"open basket and finish payment")]
        public void WhenOpenBasketAndFinishPayment()
        {
            this.global.Driver.FindElement(By.XPath("//div[@id='shopping_cart_container']")).Click();
            this.global.Driver.FindElement(By.XPath("//button[@id='checkout']")).Click();
            this.global.Driver.FindElement(By.XPath("//input[@name='firstName']")).SendKeys("Harsha");
            this.global.Driver.FindElement(By.XPath("//input[@name='lastName']")).SendKeys("k");
            this.global.Driver.FindElement(By.XPath("//input[@name='postalCode']")).SendKeys("B12 2CD");
            this.global.Driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            this.global.Driver.FindElement(By.XPath("//button[@id='finish']")).Click();
        }

        [Then(@"order complete is seen")]
        public void ThenOrderCompleteIsSeen()
        {
            WebDriverWait wait = new WebDriverWait(this.global.Driver, TimeSpan.FromSeconds(10));
            IWebElement orderPlaced = wait.Until(e => e.FindElement(By.XPath("//div[@id='checkout_complete_container']")));
            Assert.IsTrue(orderPlaced.Displayed);
            Console.WriteLine(orderPlaced.Text);
            this.global.Driver.FindElement(By.XPath("//button[@name='back-to-products']")).Click();
        }


        [When(@"open basket and leave personal information screen blank")]
        public void WhenOpenBasketAndLeavePersonalInformationScreenBlank()
        {
            this.global.Driver.FindElement(By.XPath("//div[@id='shopping_cart_container']")).Click();
            this.global.Driver.FindElement(By.XPath("//button[@id='checkout']")).Click();
           
        }

        [Then(@"enter first name error screen is seen")]
        public void ThenErrorScreenIsSeen()
        {
            this.global.Driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            string actText = "";
            string expText = "Error: First Name is required";
            string actResult = this.global.Driver.FindElement(By.XPath("//h3[@data-test='error']")).GetAttribute("textContent");
            actText = actResult.ToString();
            if (actText == expText)
            {
                Console.WriteLine(actText);
            }
            else
            {
                Console.WriteLine(actResult);
            }
        }

        [Then(@"enter last name error screen is seen")]
        public void ThenEnterLastNameErrorScreenIsSeen()
        {
            this.global.Driver.FindElement(By.XPath("//input[@name='firstName']")).SendKeys("Harsha");
            this.global.Driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            string actText2 = "";
            string expText2 = "Error: Last Name is required";
            string actResult2 = this.global.Driver.FindElement(By.XPath("//h3[@data-test='error']")).GetAttribute("textContent");
            actText2 = actResult2.ToString();
            if (actText2 == expText2)
            {
                Console.WriteLine(actText2);
            }
            else
            {
                Console.WriteLine(actResult2);
            }
        }

        [Then(@"enter postal code error screen is seen")]
        public void ThenEnterPostalCodeErrorScreenIsSeen()
        {
            this.global.Driver.FindElement(By.XPath("//input[@name='firstName']")).SendKeys("Harsha");
            this.global.Driver.FindElement(By.XPath("//input[@name='lastName']")).SendKeys("k");
            this.global.Driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            string actText3 = "";
            string expText3 = "Error: Postal Code is required";
            string actResult3 = this.global.Driver.FindElement(By.XPath("//h3[@data-test='error']")).GetAttribute("textContent");
            actText3 = actResult3.ToString();
            if (actText3 == expText3)
            {
                Console.WriteLine(actText3);
            }
            else
            {
                Console.WriteLine(actResult3);
            }
        }


    }
}

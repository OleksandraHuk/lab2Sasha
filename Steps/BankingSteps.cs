using lab2.PageObjects;
using lab2Sasha.PageObjects;
using NUnit.Framework; // Ensure NUnit is referenced
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace lab2.StepDefinitions
{
    [Binding]
    public class BankingSteps
    {
        private IWebDriver? driver;
        private LoginPage? loginPage;
        private DashboardPage? dashboardPage;
        private CustomersPage? customersPage;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
            customersPage = new CustomersPage(driver);
        }

        [Given(@"I am on the Bank Manager login page")]
        public void GivenIAmOnTheBankManagerLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject/");
            loginPage = new LoginPage(driver);
        }

        [When(@"I login as a Bank Manager")]
        public void WhenILoginAsABankManager()
        {
            Thread.Sleep(1000);
            loginPage.ClickBankManagerLogin();
        }

        [Then(@"I should see the manager dashboard")]
        public void ThenIShouldSeeTheManagerDashboard()
        {
            Thread.Sleep(1000);
            var isVisible = dashboardPage?.IsDashboardVisible() ?? false;
            Assert.That(isVisible, Is.EqualTo(true), "Error: Dashboard is not visible. Login might have failed.");
        }

        [When(@"I click on Customers menu item")]
        public void WhenIClickOnCustomersMenuItem()
        {
            Thread.Sleep(1000);
            dashboardPage?.ClickOnCustomers();
        }

        [Then(@"I should see the list of customers")]
        public void ThenIShouldSeeTheListOfCustomers()
        {
            Thread.Sleep(1000);
            var isVisible = customersPage?.IsCustomersListVisible() ?? false;
            Assert.That(isVisible, Is.EqualTo(true), "Error: Customers list is not visible.");
        }

        [When(@"I click on Last Name column header")]
        public void WhenIClickOnLastNameColumnHeader()
        {
            Thread.Sleep(1000);
            customersPage?.ClickOnLastNameColumn();
        }

        [Then(@"the customers should be sorted by their last names")]
        public void ThenTheCustomersShouldBeSortedByTheirLastNames()
        {
            Thread.Sleep(1000);
            var isSorted = customersPage?.IsCustomerListSortedByLastName() ?? false;
            Assert.That(isSorted, Is.EqualTo(true), "Error: Customers list is not sorted by last names.");
        }

        [After]
        public void CloseBrowser()
        {
            driver?.Quit();
        }
    }
}
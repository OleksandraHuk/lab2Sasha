using OpenQA.Selenium;

namespace lab2.PageObjects
{
    internal class DashboardPage
    {
        private IWebDriver driver;
        private By customersMenuItem = By.XPath("//button[contains(text(),'Customers')]");

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnCustomers()
        {
            driver.FindElement(customersMenuItem).Click();
        }

        public bool IsDashboardVisible()
        {
            // Проверяет, отображается ли элемент, уникальный для дашборда
            try
            {
                return driver.FindElement(customersMenuItem).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
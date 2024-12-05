using OpenQA.Selenium;


namespace lab2Sasha.PageObjects
{
    internal class LoginPage
    {
        private IWebDriver driver;
        private By managerLoginBtn = By.XPath("//button[contains(text(),'Bank Manager Login')]");
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickBankManagerLogin()
        {
            driver.FindElement(managerLoginBtn).Click();
        }
    }

}

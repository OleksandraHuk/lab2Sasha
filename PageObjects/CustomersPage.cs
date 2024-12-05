using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace lab2.PageObjects
{
    internal class CustomersPage
    {
        private IWebDriver driver;
        private By lastNameColumnHeader = By.XPath("/html/body/div/div/div[2]/div/div[2]/div/div/table/thead/tr/td[2]/a");
        private By customersTable = By.CssSelector(".table.table-bordered.table-striped");

        public CustomersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnLastNameColumn()
        {
            driver.FindElement(lastNameColumnHeader).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElements(By.CssSelector(".table.table-bordered.table-striped tbody tr.ng-scope")).Count > 0);
        }

        public bool IsCustomersListVisible()
        {
           
            try
            {
                return driver.FindElement(customersTable).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsCustomerListSortedByLastName()
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.CssSelector(".table.table-bordered.table-striped tbody tr.ng-scope")).Displayed);
            var rows = driver.FindElements(By.CssSelector(".table.table-bordered.table-striped tbody tr.ng-scope"));
            List<string> lastNames = rows.Select(row => row.FindElements(By.TagName("td"))[1].Text).ToList();

         
            Console.WriteLine("Список прізвищ: " + string.Join(", ", lastNames));

          
            bool isSortedDescending = lastNames.SequenceEqual(lastNames.OrderByDescending(x => x));
            

            return isSortedDescending;
        }
    }

}
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Phonebook.AutomatedUITests
{
    public class AutomatedUITests
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Create_WhenExecuted_ReturnsCreateView()
        {
            string URL = "https://localhost:7191/";
            _driver.Navigate().GoToUrl(URL);
            _driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a")).Click();
            var contactTitle = _driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/div[3]/a"));
            string title = contactTitle.Text;
            contactTitle.Click();
            _driver.FindElement(By.Id("Name")).SendKeys("Robert");
            _driver.FindElement(By.Id("PhoneNumber")).SendKeys("+420792733051");
            _driver.FindElement(By.XPath("/html/body/div[1]/main/form/div/div[2]/div[1]/div[3]/div/div[1]/input")).Click();
            contactTitle = _driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/div[3]/a"));
            Assert.Equal(title, contactTitle.Text);
        }
    }
}
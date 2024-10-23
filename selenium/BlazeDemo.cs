namespace BlazeDemo;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

[TestFixture]
public class AddPassagemTeste{

private IWebDriver driver;

[SetUp]
public void Before(){
    new DriverManager().SetUpDriver(new ChromeConfig());
    driver = new ChromeDriver();
    driver.Manage().Window.Maximize();
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
}

[TearDown]

public void After(){
    driver.Quit();
}

[Test]

public void compra(){
    driver.Navigate().GoToUrl("https://www.blazedemo.com/");
    Thread.Sleep(1000);
    driver.FindElement(By.Name("fromPort")).SendKeys("Boston");
    Thread.Sleep(1000);
    driver.FindElement(By.Name("toPort")).SendKeys("London");
    Thread.Sleep(1000);
    driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
    Thread.Sleep(2000);    
    driver.FindElement(By.CssSelector("input.btn.btn-small")).Click();
    Thread.Sleep(1000);
    driver.FindElement(By.Name("inputName")).SendKeys("Guilherme VIlela");
    driver.FindElement(By.Id("address")).SendKeys("Rua Teste");
    driver.FindElement(By.Id("city")).SendKeys("Teste");
    driver.FindElement(By.Id("state")).SendKeys("Espirito Santo");
    driver.FindElement(By.Id("zipCode")).SendKeys("29260000");
    driver.FindElement(By.Name("creditCardNumber")).SendKeys("123456789");
    driver.FindElement(By.Name("creditCardYear")).SendKeys("2028");
    driver.FindElement(By.Id("nameOnCard")).SendKeys("Guilherme Ferreira");
    driver.FindElement(By.Name("rememberMe")).Click();
    driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
    Assert.AreEqual(driver.FindElement(By.CssSelector("div.container.hero-unit h1")).Text, "Thank you for your purchase today!");
    Assert.AreEqual(driver.FindElement(By.CssSelector("tr:nth-child(3) td:last-child")).Text, "555 USD");
    Thread.Sleep(2000);  

}

}
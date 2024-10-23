// 1 - Namespace (Pacote - Grupo de Classes - Workspace)
namespace SeleniumSimples;


// 2 - Bibliotecas (Dependencias)
using OpenQA.Selenium;
using System.Security.Policy;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.DevTools.V127.IndexedDB;

// 3 - Classe (PUBLIC todas as classes podem enxergar, PRIVATE não)
[TestFixture] // confoigura como uma classe de teste

// deve ser escrito TEST em algum lugar do nome da classe para ser um teste
public class AdicionarProdutoNoCarrinhoTest {

    //3.1 - Atributos - caracteristicas - campos
    private IWebDriver driver; //objeto de Slenium WebDriver
    
    //3.2 - Funções(retorna algo -  return) e Métodos(apenas faz)  
  
    //3.3 - Configurações de Antes do Teste 
    [SetUp] // Configura um método para ser executado antes dos testes
    public void Before(){
        // faz o download e instalação da versão mais recente do ChromeDriver
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();  // Instancia o objeto do selenium como chrome
        driver.Manage().Window.Maximize(); // Maximiza a janela do navegador
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000); // COnfigura uma espera de x segundos para qualquer elemento aparecer
    } // Fim do Before

    //3.4 - Configurações de Depois do Teste
    [TearDown] // Configura um método para ser usado depois dos testes
    public void After(){
        driver.Quit(); // Destruir o objeto do Selenium na memória
    } // fim do After

    //3.5 - O(s) Teste(s)
    [Test] // indica que é um método de teste
    public void Login(){
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");  // Abrir o navegador e acessar o site
        Thread.Sleep(2000); // Pausa forçada - remover antes de publicar
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user"); // preencher usuario
        driver.FindElement(By.Name("password")).SendKeys("secret_sauce"); // Preencher senha
        driver.FindElement(By.CssSelector("input.submit-button.btn_action")).Click(); // Clicar do botão
        Thread.Sleep(2000);
        Assert.AreEqual(driver.FindElement(By.CssSelector("Span.title")).Text, "Products");   // Verificar se fizemos o login no sistema confirmando um texto ancora
        Thread.Sleep(2000); // Pausa forçada - remover antes de publicar
        } // Fim do Login
     

} //Fim da classe
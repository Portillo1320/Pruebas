using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace PruebasCalculadora
{
    class Program
    {
        static void Main(string[] args)
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                //Proyecto
                driver.Navigate().GoToUrl(@"C:\Users\airam\Downloads\PruebasCalculadora\Calculadora.html");

                //Prueba de Suma
                //Puse resultado erroneo para que de fallido
                Console.WriteLine("Prueba de Suma:");
                EjecutarPrueba(driver, "5", "3", "btnSumar", "Resultado: 6");

                //Prueba de Resta
                Console.WriteLine("Prueba de Resta:");
                EjecutarPrueba(driver, "10", "4", "btnRestar", "Resultado: 6");

                //Prueba de Multiplicación
                Console.WriteLine("Prueba de Multiplicación:");
                EjecutarPrueba(driver, "7", "6", "btnMultiplicar", "Resultado: 42");

                //Prueba de División
                Console.WriteLine("Prueba de División:");
                EjecutarPrueba(driver, "8", "2", "btnDividir", "Resultado: 4");

                //Prueba de División por Cero
                Console.WriteLine("Prueba de División por Cero:");
                EjecutarPrueba(driver, "8", "0", "btnDividir", "Resultado: Infinito");

                Console.WriteLine("Pruebas completadas.");
            }
        }

        static void EjecutarPrueba(IWebDriver driver, string num1, string num2, string botonId, string resultadoEsperado)
        {

            var inputNum1 = driver.FindElement(By.Id("num1"));
            var inputNum2 = driver.FindElement(By.Id("num2"));
            var boton = driver.FindElement(By.Id(botonId));
            var resultado = driver.FindElement(By.Id("resultado"));


            inputNum1.Clear();
            inputNum1.SendKeys(num1);
            inputNum2.Clear();
            inputNum2.SendKeys(num2);


            boton.Click();


            if (resultado.Text == resultadoEsperado)
            {
                Console.WriteLine($"Prueba exitosa: {resultado.Text}");
            }
            else
            {
                Console.WriteLine($"Prueba fallida. Se esperaba: {resultadoEsperado}, pero se obtuvo: {resultado.Text}");
            }
        }
    }
}

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidAppiumTests
{
    public class AndroidAppiumCalculatorTests
    {
        private const string appiumUrl = "http://[::1]:4723/wd/hub";
        private const string appLocation = @"C:\Users\diana\Downloads\Appium Mobile Testing\Resources\com.example.androidappsummator.apk";
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options; 

        [OneTimeSetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumUrl), options);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Calculate_TwoPositiveNumbers()
        {
            var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            firstInput.Clear();
            secondInput.Clear();
            firstInput.SendKeys("5");
            secondInput.SendKeys("6");
            calcButton.Click();

            var result = resultField.Text;

            Assert.That(result, Is.EqualTo("11"));
        }
        [Test]
        public void Test_Calculate_InvalidValues()
        {
            var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            firstInput.Clear();
            secondInput.Clear();
            firstInput.SendKeys("5");
            secondInput.SendKeys("alabala");
            calcButton.Click();

            var result = resultField.Text;

            Assert.That(result, Is.EqualTo("error"));
        }
    }
}
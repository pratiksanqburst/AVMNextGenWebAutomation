using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenPageObjects
{
    public class TestDataUtils:AVMNextGenBase
    {
        IWebDriver testDataUtilsDriver;
        public TestDataUtils() { }

        public TestDataUtils(IWebDriver driver)
        {
            this.testDataUtilsDriver = driver;
        }

        #region Properties
        IWebElement loadingIcon => driver.FindElement(By.Id("loading-bar-spinner"));
        string iconText = "loading-bar-spinner";
        #endregion

        #region Method
        /// <summary>
        /// Wait for loader icon to disappear
        /// </summary>
        public void WaitForLoading()
        {
            try
            {
            wait.Until(driver => loadingIcon.Displayed);
            }
            catch (Exception)
            {

            }
            wait.Until(driver => driver.FindElements(By.Id("loading-bar-spinner")).Count == 0);
            Thread.Sleep(1000);
        }
        #endregion
    }
}

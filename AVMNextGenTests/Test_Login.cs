using AVMNextGenWebAutomation.AVMNextGenPageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMNextGenWebAutomation.AVMNextGenTests
{
    [Category("Login")]
    public class Test_Login:Login
    {
        [Test]
        public void Test_Login_Validation()
        {
            LoginToAVMLite(userName, password);
           
        }

    }
}

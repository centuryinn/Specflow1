using SpecFlow1.Drivers;
using SpecFlow1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.StepDefinitions
{
    [Binding]
    public class EmployeeDetails
    {

        private DriverHelper _driverHelper;
        HomePage homePage;
        LoginPage loginPage;

        public EmployeeDetails(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
        }
    }
}
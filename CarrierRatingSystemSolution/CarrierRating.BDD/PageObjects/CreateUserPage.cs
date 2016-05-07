using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CarrierRating.BDD.PageObjects
{
    public class CreateUserPage
    {
        [FindsBy(How=How.Id, Using = "UserDTO_FirstName")]
        private readonly IWebElement Firstname;
        [FindsBy(How=How.Id, Using ="UserDTO_LastName")]
        private readonly IWebElement Lastname;
        private static IWebDriver Driver;

        public static CreateUserPage NavigateTo(IWebDriver driver)
        {
            Driver = driver;
            driver.Navigate().GoToUrl("http://localhost:61761/Account/Create");
            var createUserPage = new CreateUserPage();
            PageFactory.InitElements(Driver, createUserPage);
            return createUserPage;
        }

        public bool InsertNameInTextFieldFirstname(string nameToInsert)
        {
            Firstname.SendKeys(nameToInsert);
            var firstnamevalue = Firstname.GetAttribute("value");
            return firstnamevalue.Equals(nameToInsert);
        }

        public bool InsertNameInTextFieldLastname(string nameToInsert)
        {
            Lastname.SendKeys(nameToInsert);
            var lastnamevalue = Lastname.GetAttribute("value");
            return lastnamevalue.Equals(nameToInsert);
        }
    }
}

using CarrierRating.BDD.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace CarrierRating.BDD.GeneratedSteps
{

    [Binding]
    public class AddUserSteps
    {
        private CreateUserPage CreateUserPage;
        private IWebDriver Driver;

        [BeforeScenario]
        public void Setup()
        {
            Driver = new ChromeDriver();
            CreateUserPage = CreateUserPage.NavigateTo(Driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Given(@"I have entered '(.*)' into the text field firstname")]
        public void GivenIHaveEnteredIntoTheTextFieldFirstname(string firstname)
        {
            Assert.AreEqual(true, CreateUserPage.InsertNameInTextFieldFirstname(firstname)); 
        }
        
        [Given(@"I have entered '(.*)' into the text field lastname")]
        public void GivenIHaveEnteredIntoTheTextFieldLastname(string lastname)
        {
            Assert.AreEqual(true, CreateUserPage.InsertNameInTextFieldLastname(lastname));
        }

        [Given(@"I have entered '(.*)' into the text field email")]
        public void GivenIHaveEnteredIntoTheTextFieldEmail(string email)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have entered '(.*)' into the text field password")]
        public void GivenIHaveEnteredIntoTheTextFieldPassword(int password)
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I press create")]
        public void WhenIPressCreate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a message with '(.*)' should be displayed on the screen")]
        public void ThenAMessageWithShouldBeDisplayedOnTheScreen(string successMessage)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

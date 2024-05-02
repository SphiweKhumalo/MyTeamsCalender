using System.Threading.Tasks;
using MyTeamsCalender.Models.TokenAuth;
using MyTeamsCalender.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyTeamsCalender.Web.Tests.Controllers
{
    public class HomeController_Tests: MyTeamsCalenderWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
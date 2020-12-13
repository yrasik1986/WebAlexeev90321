using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebAlexeev90321.Controllers;
using WebAlexeev90321.DAL.Entities;
using WebAlexeev90321.DAL.Data;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace WebAlexeev90321.Tests
{
    public class ProductControllerTests : Controller
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests()
        {
            _options =
           new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "testDb")
            .Options;
        }
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType =
       typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());

            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };
                // Act
                var result = controller.Index(group: null, pageNo:
               page) as ViewResult;
                var model = result?.Model as List<RadioComponent>;
                // Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].RadioComponentId);
            }
            // удалить базу данных из памяти
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }

        }
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };

                var comparer = Comparer<RadioComponent>.GetComparer((d1, d2) =>
               d1.RadioComponentId.Equals(d2.RadioComponentId));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<RadioComponent>;
                // assert
                Assert.Equal(2, model.Count);
                Assert.Equal(context.RadioComponents
                .ToArrayAsync()
               .GetAwaiter()
               .GetResult()[2], model[0], comparer);
            }
        }
    }

    public class TestData
    {
        public static void FillContext(ApplicationDbContext context)
        {
            context.RadioComponentGroups.Add(new RadioComponentGroup
            {GroupName = "fake group" });
            context.AddRange(new List<RadioComponent>
            {
                new RadioComponent {RadioComponentId=1, RadioComponentGroupId = 1},
                new RadioComponent {RadioComponentId=2, RadioComponentGroupId = 2},
                new RadioComponent {RadioComponentId=3, RadioComponentGroupId = 3},
                new RadioComponent {RadioComponentId=4, RadioComponentGroupId = 2},
                new RadioComponent {RadioComponentId=5, RadioComponentGroupId = 3},
                new RadioComponent {RadioComponentId=6, RadioComponentGroupId = 1},
                new RadioComponent {RadioComponentId=7, RadioComponentGroupId = 1},
                new RadioComponent {RadioComponentId=8, RadioComponentGroupId = 2},
                new RadioComponent {RadioComponentId=9, RadioComponentGroupId = 3},
                new RadioComponent {RadioComponentId=10, RadioComponentGroupId = 2},
                new RadioComponent {RadioComponentId=11, RadioComponentGroupId = 3},
                new RadioComponent {RadioComponentId=12, RadioComponentGroupId = 1}
            });
            context.SaveChanges();
        }


        public static List<RadioComponent> GetRadioComponentsList()
        {
            return new List<RadioComponent>
            {
                new RadioComponent{ RadioComponentId=1, RadioComponentGroupId = 2},
                new RadioComponent{ RadioComponentId=2, RadioComponentGroupId = 2},
                new RadioComponent{ RadioComponentId=3, RadioComponentGroupId = 3},
                new RadioComponent{ RadioComponentId=4, RadioComponentGroupId = 1},
                new RadioComponent{ RadioComponentId=5, RadioComponentGroupId = 3},
                new RadioComponent{ RadioComponentId=6, RadioComponentGroupId = 3} //&&&&&&&&&
            };
        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4&&&&&&&&&&
            yield return new object[] { 2, 3, 4 };
        }

    }


}

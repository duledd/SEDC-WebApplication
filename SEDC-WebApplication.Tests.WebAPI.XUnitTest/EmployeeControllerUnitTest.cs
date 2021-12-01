using Microsoft.AspNetCore.Mvc;
using SEDC_WebAPI.Controllers;
using SEDC_WebAPI.Services.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Tests.WebAPI.XUnitTest.Mock;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SEDC_WebApplication.Tests.WebAPI.XUnitTest
{
    public class EmployeeControllerUnitTest
    {
        EmployeeController _controller;
        IDataService _service;
        public EmployeeControllerUnitTest()
        {
            _service = new DataServiceMock();
            _controller = new EmployeeController(_service, null, null);
        }
        [Fact]
        public async Task Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = await _controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        //[Fact]
        //public void Get_WhenCalled_ReturnsAllItems()
        //{
        //    //Act
        //    var okResult = _controller.Get().Result as OkObjectResult;

        //    //Assert
        //    var items = Assert.IsType<List<EmployeeDTO>>(okResult.Value);
        //    Assert.Equal(3, items.Count);
        //}

        //[Theory]
        //[InlineData(1)]
        //public void GetById_WhenCalled_ReturnsOkResult(int id)
        //{
        //    //Act
        //    var okResult = _controller.Get(id);

        //    //Assert
        //    Assert.IsType<ObjectResult>(okResult);
        //}

        //[Theory]
        //[InlineData(1)]
        //public async Task GetById_WhenCalled_ReturnsRightItem(int id)
        //{
        //    //Act
        //    var okResult = (await _controller.GetById(id).Result as OkObjectResult);

        //    //Assert
        //    var item = Assert.IsType<EmployeeDTO>(okResult.Value);
        //    Assert.Equal("Pera", item.Name);
        //}
    }
}

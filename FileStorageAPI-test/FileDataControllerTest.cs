using System;
using System.Net;
using FileStorageAPI.Controllers;
using FileStorageAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FileStorageAPI.Entities;
using System.Text;

namespace FileStorageAPI_test;

public class FileDataControllerTest
{
    private readonly IFileDataService fileDataService;
    private readonly FileDataController controller;

    public FileDataControllerTest()
    {
        this.fileDataService = new FileDataService();
        this.controller = new FileDataController(fileDataService);
    }


    //public FileDataControllerTest()
    //{
    //    this.fileDataService = new FileDataService();
    //    this.controller = new FileDataController(fileDataService);
    //}

    //[Fact]
    //public void GetFile()
    //{
    //    // Arrange
    //    int fileId = 1;
    //    // Act
    //    var okResult = controller.GetFile(fileId);
    //    // Assert
    //    //Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    //    Assert.Contains<Byte>;
    //}

    [Fact]
    public void PostFile()
    {
        var content = "Dummy File";
        var fileName = "test.pdf";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;

        //create FormFile with desired data
        var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
        IFormFile file = new FormFile(stream, 0, stream.Length, "data", fileName);
        FileRequest fileRequest = new FileRequest();
        fileRequest.UserId = 1;
        fileRequest.File = file;
        

        //Act
        var result = controller.SubmitPost(fileRequest);

        //Assert
        //Assert.IsType(result, typeof(IActionResult));
        //Assert.IsType<ActionResult>(result);
        //Assert.IsAssignableFrom<System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>>(result);
        Assert.IsType<System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>>(result);

    }
}

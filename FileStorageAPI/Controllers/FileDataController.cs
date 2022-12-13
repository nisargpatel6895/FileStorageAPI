        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using FileStorageAPI.Entities;
        using FileStorageAPI.Response;
        using FileStorageAPI.Services;
        using Microsoft.AspNetCore.Http.Extensions;
        using Microsoft.AspNetCore.Mvc;

        // For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

        namespace FileStorageAPI.Controllers
        {
            [ApiController]
            [Route("[controller]")]
            public class FileDataController : Controller
            {
                private readonly IFileDataService fileDataService;

                public FileDataController(IFileDataService fileDataService)
                {
                    this.fileDataService = fileDataService;
                }

                [HttpPost("UploadFile")]
                //[RequestSizeLimit(5 * 1024 * 1024)]
                public async Task<IActionResult> SubmitPost([FromForm] FileRequest fileRequest)
                {
                    if (fileRequest == null)
                    {
                        return BadRequest(new FileDataResponse { Success = false, Error = "Invalid post request" });
                    }

                        try
                        {
                            await fileDataService.PostFile(fileRequest);
                            return Ok();
                        }
                        catch(Exception)
                        {
                            throw;
                        }
            
                }

                [HttpGet("DownloadFile")]
                public async Task<ActionResult> GetFile(int id)
                {
                    if (id < 1)
                    {
                        return BadRequest(new FileDataResponse { Success = false, Error = "Invalid post request" });
                    }

                    try
                    {
                        await fileDataService.GetFileById(id);
                        return Ok();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                [HttpPut("UpdateFile")]
                public async Task<ActionResult> UpdateFile(int id, [FromForm] FileRequest fileRequest)
                {
                    if (id < 1 || fileRequest == null)
                    {
                        return BadRequest(new FileDataResponse { Success = false, Error = "Invalid post request" });
                    }

                    try
                    {
                        await fileDataService.UpdateFile(id ,fileRequest);
                        return Ok();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                [HttpDelete("DeleteFile")]
                public async Task<ActionResult> DeleteFile(int id)
                {
                    if (id < 1)
                    {
                        return BadRequest(new FileDataResponse { Success = false, Error = "Invalid post request" });
                    }

                    try
                    {
                        await fileDataService.DeleteFile(id);
                        return Ok();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
            using System;
            using System.IO;
            using FileStorageAPI.Entities;
            using FileStorageAPI.Response;
            using Microsoft.Extensions.Hosting;
            using Microsoft.VisualBasic.FileIO;

            namespace FileStorageAPI.Services
            {
	            public class FileDataService : IFileDataService
	            {
                    private readonly FileStorageDbContext fileStorageDbContext;


                    public FileDataService(FileStorageDbContext fileStorageDbContext)
                    {
                        this.fileStorageDbContext = fileStorageDbContext;
                    }

                    public FileDataService()
                    {
            
                    }

                    public async Task<FileDataResponse> PostFile(FileRequest fileRequest)
                    {
                        try
                        {
                            var fileData = new FileData()
                            {
                                Id = 0,
                                UserId = fileRequest.UserId,
                                FileName = fileRequest.File.FileName,
                                Timestamp = DateTime.Now
                            };

                            using (var stream = new MemoryStream())
                            {
                                fileRequest.File.CopyTo(stream);
                                fileData.Data = stream.ToArray();
                            }

                            var result = fileStorageDbContext.FileData.Add(fileData);
                            await fileStorageDbContext.SaveChangesAsync();
                            return new FileDataResponse { Success = true, FileData = fileData };

                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                    public async Task<FileDataResponse> UpdateFile(int id, FileRequest fileRequest)
                    {
                        try
                        {
                            var existingFile = fileStorageDbContext.FileData.Where(x => x.Id == id).FirstOrDefault();
                            //var fileData = new FileData()
                            //{
                            //    Id = id,
                            //    UserId = fileRequest.UserId,
                            //    FileName = fileRequest.File.FileName,
                            //    Timestamp = DateTime.Now
                            //};
                            if(existingFile != null)
                            {
                                existingFile.UserId = fileRequest.UserId;
                                existingFile.FileName = fileRequest.File.FileName;
                                existingFile.Timestamp = DateTime.Now;
                                using (var stream = new MemoryStream())
                                {
                                    fileRequest.File.CopyTo(stream);
                                    existingFile.Data = stream.ToArray();
                                }
                            }

                            var result = fileStorageDbContext.FileData.Update(existingFile);
                            await fileStorageDbContext.SaveChangesAsync();
                            return new FileDataResponse { Success = true, FileData = existingFile };

                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                    public async Task GetFileById(int Id)
                    {
                        try
                        {
                            var file = fileStorageDbContext.FileData.Where(x => x.Id == Id).FirstOrDefault();

                            var content = new System.IO.MemoryStream(file.Data);
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "DownloadedFiles", file.FileName);

                            await CopyFileDataStream(content, path);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                    public async Task CopyFileDataStream(Stream stream, string downloadPath)
                    {
                        using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }

                    public async Task DeleteFile(int Id)
                    {
                        try
                        {
                            var file = fileStorageDbContext.FileData.Where(x => x.Id == Id).FirstOrDefault();
                            var result = fileStorageDbContext.FileData.Remove(file);

                            var content = new System.IO.MemoryStream(file.Data);
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "DownloadedFiles", file.FileName);
                            System.IO.File.Delete(path);

                            await fileStorageDbContext.SaveChangesAsync();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                }
            }

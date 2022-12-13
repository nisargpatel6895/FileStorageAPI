using System;
using FileStorageAPI.Entities;
using FileStorageAPI.Response;
using Microsoft.VisualBasic.FileIO;

namespace FileStorageAPI.Services
{
	public interface IFileDataService
	{
        Task GetFileById(int fileId);

        Task<FileDataResponse> PostFile(FileRequest fileRequest);

        Task<FileDataResponse> UpdateFile(int fileId, FileRequest fileRequest);

        Task DeleteFile(int fileId);
    }
}


using System;
using System.Text.Json.Serialization;

namespace FileStorageAPI.Entities
{
	public class FileRequest
	{
        public int UserId { get; set; }
        //public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}


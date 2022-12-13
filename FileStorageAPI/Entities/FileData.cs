using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorageAPI.Entities
{
    [Table("FileData")]
    public class FileData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        //public string ImagePath { get; set; }
        public DateTime Timestamp { get; set; }
        
	}
}


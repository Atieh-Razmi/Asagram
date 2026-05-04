using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class AppFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Data { get; set; } = null!;
        public string ContentType { get; set; } = null!;

        public FileType FileType { get; set; }
        public User? User { get; set; }
    }
}

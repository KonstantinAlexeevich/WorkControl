using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WorkControl.Storage.Abstractions
{
    public class Document
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<DocumentWork> DocumentWorks { get; set; } = new();
        public string CreateUserId { get; set; }
        public IdentityUser CreateUser { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Services.DTO
{
    public class ItemDTO
    {
        public long Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public IFormFile Photos { get; set; }
        public string PhotoUrl { get; set; }
        public bool WonOrBought { get; private set; }

        public ItemDTO() { }

        public ItemDTO(long id, string title, string description, string link, IFormFile photos, string photoUrl, bool wonOrBought)
        {
            Id = id;
            Title = title;
            Description = description;
            Link = link;
            Photos = photos;
            PhotoUrl = photoUrl;
            WonOrBought = wonOrBought;
        }
    }
}
using LibraryApp.API.DTO;
using LİbraryApp.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.API.Models
{
    public class UserLibraryModel
    {
        public string UserId { get; set; }
        public List<BookModel> BookModels { get; set; }

    }
}

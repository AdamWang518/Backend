using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class ArticleModel
    {
        public Guid ID;
        public Guid CatalogID;
        public string Title;
        public string Article;
        public string Image;
    }
}
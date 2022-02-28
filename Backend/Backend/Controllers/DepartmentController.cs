using Backend.Models;
using Backend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class DepartmentController : ApiController
    {
       [HttpGet]
       [Route("getDepartments")]
       public List<DepartmentModel> getDepartments(Guid TypeID,String Institude)
        {
            Database database = new Database();
            String sql = $@"select ID,TypeID,Institude,Department,Name,Image from Catalog
                           where Institude = '{Institude}' AND TypeID='{TypeID}'";
           return database.Query<DepartmentModel>(sql);
        }
        [HttpGet]
        [Route("getOptionStage1")]
        public List<OptionModel> getOptionsStage1(Guid TypeID, String Department)
        {
            Database database = new Database();
            
            String sql = $@"select ID,TypeID,[Option],Department,Name,Image from Catalog
                           where Department = '{Department}' AND TypeID='{TypeID}'";
            return database.Query<OptionModel>(sql);
        }
        [HttpGet]
        [Route("getOptionStage2")]
        public List<OptionModel> getOptionsStage2(String Option, String Department)
        {
            Database database = new Database();
           
            String sql = $@"select ID,TypeID,[Option],Department,Name,Image from Catalog
                           where Department = '{Department}' AND [Option]='{Option}'";
            return database.Query<OptionModel>(sql);
        }
        [HttpGet]
        [Route("getArticle")]
        public List<ArticleModel> getArticle(Guid CatalogID)
        {
            Database database = new Database();
            String sql = $@"select * from Article
                           where CatalogID = '{CatalogID}'";
            return database.Query<ArticleModel>(sql);
        }
        [HttpGet]
        [Route("getVoice")]
        public List<ArticleModel> getVoice(String voice)
        {
            Database database = new Database();
            String sql = $@"select * from Catalog
                           where Department = '{voice}'";
            return database.Query<ArticleModel>(sql);
        }//未完成
    }
}

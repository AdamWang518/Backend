using Backend.Models;
using Backend.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    public class DepartmentController : ApiController
    {
       [HttpGet]
       [Route("getDepartments")]
       public List<DepartmentModel> getDepartments(String TypeID,String Institude)
        {
            Database database = new Database();
            String sql = $@"select ID,TypeID,Institude,Department,Name from Catalog
                           where Institude = N'{Institude}' AND TypeID='{TypeID}'";
            List<DepartmentModel> list = database.Query<DepartmentModel>(sql);
            database.sqlConnection.Close();
            return list;
        }
        [HttpGet]
        [Route("getOption")]
        public List<OptionModel> getOption(Guid TypeID, String Department)
        {
            Database database = new Database();
            
            String sql = $@"select ID,TypeID,[Option],Department,Name from Catalog
                           where Department = N'{Department}' AND TypeID='{TypeID}'";
            List<OptionModel> list = database.Query<OptionModel>(sql);
            database.sqlConnection.Close();
            return list;
        }
        
        [HttpGet]
        [Route("getArticle")]
        public ArticleModel getArticle(Guid CatalogID)
        {
            Database database = new Database();
            String sql = $@"select * from Article
                           where CatalogID = '{CatalogID}'";
            ArticleModel model = database.Query<ArticleModel>(sql)[0];
            database.sqlConnection.Close();
            return model;
        }
        [HttpGet]
        [Route("getVoice")]
        public List<BuildingModel> getVoice(String text)
        {
            if(!String.IsNullOrWhiteSpace(text))
            {
                Database database = new Database();
                String sql = $@"select Catalog.Department,Catalog.Floor,Building.Name as BuildingName from Catalog JOIN Building ON Catalog.BuildingID = Building.ID
                           where Catalog.TypeID='180C275A-0AA8-4C47-B940-8E675FBB7C8B'";
                List<BuildingModel> list = database.Query<BuildingModel>(sql);
                database.sqlConnection.Close();
                char[] textArray = text.ToCharArray();
                Dictionary<String, int> dict = new Dictionary<string, int>();
                foreach (BuildingModel model in list)
                {
                    foreach (char word in textArray)
                    {
                        if (model.Department.Contains(word))
                        {
                            model.Similarity++;
                        }
                        //if(dict.ContainsKey())
                        //{
                        //    dict[""] +=1
                        //} else
                        //{
                        //    dict.Add("", 1);
                        //}
                    }
                }
                list = list.Where(x => x.Similarity != 0).OrderByDescending(x => x.Similarity).ToList();
                if(list.Count>0)
                {
                    var maxTimes = list[0].Similarity;
                    list = list.Where(x => x.Similarity == maxTimes).OrderBy(x => x.Department.Length).ToList();
                }
                else
                {
                    list=new List<BuildingModel>();
                }
                return list;
            } else
            {
                return new List<BuildingModel>();
            }
        }


        [HttpGet]
        [Route("Test")]
        public String Test()
        {
            return "Hello World API";
        }
        [HttpGet]
        [Route("AkinatorRequest")]
        public Response AkinatorRequest()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\Tree\\data.json");
            //StreamReader sr = new StreamReader("D:\\Vscode\\Python\\Akinator\\data.json");
            String json = sr.ReadToEnd();
            Node akinatorNode=JsonConvert.DeserializeObject<Node>(json);
            if (akinatorNode == null)
            {
                akinatorNode = new Node("資訊工程學系");
            }
            sr.Close();
            return new Response(true,akinatorNode);
        }
        [HttpPost]
        [Route("AkinatorResponse")]
        public Response AkinatorResponse(Node response)
        {
            String json = JsonConvert.SerializeObject(response);
            StreamWriter outputFile = new StreamWriter("C:\\Users\\Administrator\\Desktop\\Tree\\data.json");
            //StreamWriter outputFile = new StreamWriter("D:\\Vscode\\Python\\Akinator\\data.json");
            outputFile.WriteLine(json);
            outputFile.Flush();
            outputFile.Close();
            return new Response();
        }
    }

}

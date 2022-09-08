using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Response
    {
        public int Code { get; set; } = 200;
        public bool Success { get; set; } = true;
        public String Message { get; set; } = "執行完成";
        public object Data { get; set; }

        public Response(int Code,bool Success,String Message)
        {
            this.Code = Code;
            this.Success = Success;
            this.Message = Message;
        }

        public Response(bool Success,object Data)
        {
            this.Success = Success;
            this.Data = Data;
        }

        public Response()
        {

        }
    }
}
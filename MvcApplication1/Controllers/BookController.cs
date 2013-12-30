using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

using CommonController;
using Shared;
using Shared.Models;
using System.Web.Mvc;
using System.Web.Http;
using System.IO;
using System.Net.Http;
using System.Drawing;

namespace MvcApplication1.Controllers
{
    public class BookController : ApiController
    {
        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        public List<BookModel> Get()
        {
            SharedController commonController = new SharedController();
            List<BookModel> returnData = commonController.ExecuteOperation(OperationType.Read, null) as List<BookModel>;

            return returnData;
        }
       
       
       
        /// <summary>
        /// Get book by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BookModel> GetBookById(Int32 id)
        {
            SharedController commonController = new SharedController();
            Dictionary<String, Object> data = new Dictionary<String, Object>();
            data.Add("id", id);
            List<BookModel> returnData = commonController.ExecuteOperation(OperationType.ReadById, data) as List<BookModel>;

            return returnData;
        }

        /// <summary>
        /// Get all books of the required category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<BookModel> Get(String category)
        {
            SharedController commonController = new SharedController();
            Dictionary<String, Object> data = new Dictionary<String, Object>();
            data.Add("category", category);
            List<BookModel> returnData = commonController.ExecuteOperation(OperationType.ReadByCategory, data) as List<BookModel>;

            return returnData;
        }


    }
}
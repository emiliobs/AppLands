

namespace Lands.Backend.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using Lands.Backend.Models;
    using Lands.Domain;
    public class DBHelper
    {
        public static async Task<Response> SaveChanges(LocalDataContext db)
        {
            try
            {
                await db.SaveChangesAsync();

                return new Response(){ IsSuccess = true};
            }
            catch (Exception ex)
            {
                var response = new Response(){IsSuccess = false};

                if (ex.InnerException != null && 
                    ex.InnerException.InnerException != null && 
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    response.Message = "There is a record with the same value.";
                }
                else if(ex.InnerException != null && ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "THe record cann't be delete it has related records.";
                }
                else
                {
                    response.Message = ex.Message;
                }

                return response;
            }
        }
    }
}
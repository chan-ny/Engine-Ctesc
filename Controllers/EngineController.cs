using System;
using System.Data;
using System.Data.Odbc;
using Microsoft.AspNetCore.Mvc;

namespace Engine_Ctesc.Controllers;

[ApiController]
[Route("[controller]")]
public class EngineController : ControllerBase
{

    [HttpGet]
    public String Get()
    {
        string connectionString = "DSN=M1;";
        using (OdbcConnection conn = new OdbcConnection(connectionString))
        {
            try
            {
                conn.Open();

                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from TableCarIfo";
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return "value " + reader;
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        return "ok";

    }


}

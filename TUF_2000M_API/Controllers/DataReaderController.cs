using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TUF_2000M_API.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class DataReaderController : ControllerBase
    {
        // GET: api/DataReader
        [Authorize]
        [HttpGet]
        public List<DataModel> readTUFData()
        {

            return TUFdataAnalyser.analyseReader();
           
        }


         

      
       


    }
}

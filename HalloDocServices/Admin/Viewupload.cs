using HalloDocRepository.DataModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDocServices.Admin
{
    public class Viewupload
    {

        public Request? Requests { get; set; }

        public List<RequestWiseFile>? RequestWiseFiles { get; set; }

        public RequestClient? RequestClients { get; set; }

        public IEnumerable<IFormFile>? File { get; set; }

        public int RequestId { get; set; }
    }
}

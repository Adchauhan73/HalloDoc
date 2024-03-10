using HalloDocRepository.DataModels;
using Microsoft.AspNetCore.Http;

namespace HalloDocServices.ViewModels
{
    public class ViewDocument
    {


        public Request Requests { get; set; }

        public List<RequestWiseFile> RequestWiseFiles { get; set; }

        public RequestClient RequestClients { get; set; }

        public IEnumerable<IFormFile>? File { get; set; }

        public int RequestId { get; set; }

    }
}

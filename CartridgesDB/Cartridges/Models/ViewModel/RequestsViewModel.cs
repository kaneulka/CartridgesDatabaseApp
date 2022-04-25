using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Models.ViewModel
{
    public class RequestsViewModel
    {
        public IEnumerable<RequestViewModel> Requests { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public List<string> FailedUploadingDocxs { get; set; }
    }
}

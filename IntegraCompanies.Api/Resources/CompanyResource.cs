using System;
using System.Collections.Generic;

namespace IntegraCompanies.Api.Resources
{
    public class CompanyResource
    {
        public Guid CompanyId { get; set; }
        public string DisplayName { get; set; }
        public string OfficalName { get; set; }
        public string Note { get; set; }
        public ConnectionResource Connection { get; set; }        
        public List<string> Masks { get; set; }
    }
}


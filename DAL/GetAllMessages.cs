using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class GetAllMessages
    {
        public List<CustomMsg> Custom { set; get; }
        public List<MarkRevision> Revision { set; get; }
    }
}
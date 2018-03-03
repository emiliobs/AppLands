

namespace Lands.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Response
    {
        public bool IsSuccess { get; set; }
        public String Message { get; set; }
        public Object Result { get; set; }
    }
}

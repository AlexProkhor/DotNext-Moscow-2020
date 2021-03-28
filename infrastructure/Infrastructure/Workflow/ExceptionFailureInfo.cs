using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Workflow
{
    public class ExceptionFailureInfo : FailureInfo
    {
        public ExceptionFailureInfo(Exception e, string message = null) :
            base(FailureType.Exception, message ?? e.Message)
        { }
    }

}

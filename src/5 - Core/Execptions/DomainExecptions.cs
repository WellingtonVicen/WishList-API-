using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

namespace Core.Execptions
{
    public class DomainExecptions : Exception
    {
        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public DomainExecptions()
        { }

        public DomainExecptions(string message, List<string> errors)
        {
            _errors = errors;
        }

        public DomainExecptions(string message) : base(message)
        { }

        public DomainExecptions(string message, Exception innerExecption) : base(message, innerExecption)
        {

        }



    }
}

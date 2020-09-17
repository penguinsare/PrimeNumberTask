using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumberTask.Controllers.Models
{
    public class OperationResult
    {
        public OperationResult(string operationName, IDictionary<string, object> input, string result)
        {
            OperationName = operationName;
            Input = input;
            Result = result;
        }
        public string OperationName { get; private set; }
        public IDictionary<string, object> Input { get; private set; }
        public string Result { get; private set; }
    }
}

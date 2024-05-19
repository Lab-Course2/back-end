using MindMuse.Application.Contracts.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IOperationResult
    {
        OperationResult SuccessResult(string message = "Operation completed successfully.");
        OperationResult ErrorResult(string message, IEnumerable<string> errors);
        OperationResult ErrorResult(string v, object value);
    }
}
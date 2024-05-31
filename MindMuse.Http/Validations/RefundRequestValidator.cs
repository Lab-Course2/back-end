using FluentValidation;
using MindMuse.Http.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Http.Validations
{
    public class RefundRequestValidator : AbstractValidator<RefundRequest>
    {
        public RefundRequestValidator()
        {
            RuleFor(request => request.PaymentIntentId).NotEmpty().WithMessage("PaymentIntentId is required.");
        }
    }
}
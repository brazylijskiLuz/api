using FluentValidation;
using hackyeah.App.Application.DataAccess;
using MediatR;

namespace hackyeah.App.Application.Actions.Data;

public static class GetByFilters
{

    public sealed record Command() : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}
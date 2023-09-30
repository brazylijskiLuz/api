using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.Enums;
using MediatR;

namespace hackyeah.App.Application.Actions.Data;

public static class GetById
{
    public sealed record Command(Guid Id) : IRequest<UniversityData>;

    public class Handler : IRequestHandler<Command, UniversityData>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<UniversityData> Handle(Command request, CancellationToken cancellationToken) =>
            _unitOfWork.UniversityData.GetByIdAsync(request.Id, cancellationToken).AsTask();

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}

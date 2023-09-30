using FluentValidation;
using hackyeah.App.Application.DataAccess;
using MediatR;

namespace hackyeah.App.Application.Actions.City;

public static class GetCities
{
    public sealed record Command(string query, int page) : IRequest<List<Domain.Entities.City>>;
    public class Handler : IRequestHandler<Command, List<Domain.Entities.City>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _pageSize = 10;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Domain.Entities.City>> Handle(Command request, CancellationToken cancellationToken) => 
            _unitOfWork.Cities.GetCityAsync(request.query, request.page, _pageSize, cancellationToken);

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}
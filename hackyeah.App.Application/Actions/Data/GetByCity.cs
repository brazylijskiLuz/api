using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using MediatR;

namespace hackyeah.App.Application.Actions.Data;

public static class GetByCity
{
    public sealed record Command(Guid CityId, int page) : IRequest<List<UniversityData>>;

    public class Handler : IRequestHandler<Command, List<UniversityData>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private int _pageSize = 10;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UniversityData>> Handle(Command request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(request.CityId, cancellationToken);
            if(city is null)
            {
                throw new Exception("City not found");
            }
            
            
            return await _unitOfWork.UniversityData.GetByCityAsync(city.Name, request.page ,_pageSize, cancellationToken);
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}
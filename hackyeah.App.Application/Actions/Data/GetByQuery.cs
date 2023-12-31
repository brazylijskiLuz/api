using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.Enums;
using MediatR;

namespace hackyeah.App.Application.Actions.Data;

public static class GetByQuery
{
    public sealed record Command(string query, int page, List<InstitutionType> institutionTypes, int minPrice,
        int maxPrice, ModeOfStudy mode, string city) : IRequest<List<UniversityData>>;

    public class Handler : IRequestHandler<Command, List<UniversityData>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private int _pageSize = 10;
        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<UniversityData>> Handle(Command request, CancellationToken cancellationToken) =>
            _unitOfWork.UniversityData.GetByQueryAsync(request.query, request.page, request.institutionTypes, request.minPrice, 
                request.maxPrice, _pageSize, request.mode, request.city, cancellationToken);

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}
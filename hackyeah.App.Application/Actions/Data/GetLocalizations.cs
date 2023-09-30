using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.Enums;
using MediatR;

namespace hackyeah.App.Application.Actions.Data;

public static class GetLocalizations
{
    public sealed record Command() : IRequest<List<LocalizationData>>;

    public class Handler : IRequestHandler<Command, List<LocalizationData>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private int _pageSize = 10;
        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LocalizationData>> Handle(Command request, CancellationToken cancellationToken)
        {
            var universities = await _unitOfWork.UniversityData.GetAllAsync(cancellationToken);

            return universities.Select(university => new LocalizationData() 
                { UniversityId = university.Id, X = university.MapLocalization.X, Y = university.MapLocalization.Y })
                .ToList();
        }
        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}

public class LocalizationData
{
    public Guid UniversityId { get; set; }
    public string X { get; set; }
    public string Y { get; set; }
}


using System.Text;
using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.ValueObjects;
using MediatR;
using Newtonsoft.Json;

namespace hackyeah.App.Application.Actions;

public static class CreateDatabase
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
            var x = await _unitOfWork.Cities.GetAllAsync(cancellationToken);
            var y = await _unitOfWork.UniversityData.GetAllAsync(cancellationToken);
            var z = y.GroupBy(c => c.Address.City).Select(c => c.Key).ToList();

            foreach (var i in z)
            {
                if(await _unitOfWork.Cities.GetByNamesAsync(i, cancellationToken) != null)
                    continue;
                var d = new Domain.Entities.City
                {
                    Id = Guid.NewGuid(),
                    Name = i,
                    Voivodeship =
                        (await _unitOfWork.UniversityData.GetByFilterAsync(c => c.Address.City == i, 0, 1,
                            cancellationToken)).FirstOrDefault().Address.Province,
                    X = "0",
                    Y = "0"
                    
                    
                };
                await _unitOfWork.Cities.AddAsync(d, cancellationToken);

                Console.WriteLine(i);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
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
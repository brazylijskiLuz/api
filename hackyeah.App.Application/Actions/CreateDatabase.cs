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
            string path = "db.csv";
            int i = 0;
            var enumLines = File.ReadLines(path, Encoding.UTF8);

            foreach (var line in enumLines)
            {
                var split = line.Split(",", StringSplitOptions.TrimEntries);
//
                //int j = 0;
                //foreach (var item in split)
                //{
                //    split[j] = item.Replace("\"", "");
                //    j++;
                //}
                
                

                var data = new UniversityData()
                {
                    Address = new Address()
                    {
                        City = split[5],
                        PostCode = split[6],
                        Province = split[3],
                        Street = split[7],
                        BuildingNumber = split[8],
                        District = ""
                    },
                    InstitutionType = split[14],
                    InstitutionName = split[1],
                    CreationDateOrEntryDate = split[2],
                    KRS = split[11],
                    NIP = split[12],
                    REGON = split[10],
                    Website = split[13],
                    Id = Guid.NewGuid(),
                };
                data.MapLocalization = new MapLocalization();
                data.MapLocalization.Y = split[10];
                data.MapLocalization.X = split[9];
                await _unitOfWork.UniversityData.AddAsync(data, cancellationToken);
                Console.WriteLine(i); 
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }


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
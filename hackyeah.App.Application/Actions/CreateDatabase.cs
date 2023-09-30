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
            //string path = "db.csv";
            //int i = 0;
            //var enumLines = File.ReadLines(path, Encoding.UTF8);

            //foreach (var line in enumLines)
            //{
            //    var split = line.Split(";", StringSplitOptions.TrimEntries);

            //    var x = new City()
            //    {
            //        X = 0.ToString(),
            //        Y = 0.ToString(),
            //        Name = split[1],
            //        Voivodeship = split[2]
            //    };
            //    await _unitOfWork.Cities.AddAsync(x, cancellationToken);
            //    Console.WriteLine(i); 
            //    await _unitOfWork.SaveChangesAsync(cancellationToken);

            //    i++;
            //}


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
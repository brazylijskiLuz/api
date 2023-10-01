using System.Text;
using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.Enums;
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
            //read file
            int j = 0;
            var data = await File.ReadAllLinesAsync("db.csv", Encoding.UTF8, cancellationToken);
            foreach (var i in data)
            {
                var y = i.Split(',', StringSplitOptions.TrimEntries);
                var x = new DegreeCourse()
                {
                    Name = y[1].ToString(),
                    UniversityId = Guid.Parse(y[5].ToString()),
                    Description = y[2].ToString(),
                    Rate = Convert.ToInt32(y[3]),
                    RateCount = Convert.ToInt32(y[4]),
                    ModeOfStudy = (ModeOfStudy)int.Parse(y[6]),
                    Price = Convert.ToInt32(y[7])
                };
                j++;
                Console.WriteLine(j);
                await _unitOfWork.DegreeCourses.AddAsync(x, cancellationToken);
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
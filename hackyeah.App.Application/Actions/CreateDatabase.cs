using System.Text;
using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.Enums;
using hackyeah.App.Domain.ValueObjects;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            int it = 0;
            dynamic data = JsonConvert.DeserializeObject(await File.ReadAllTextAsync("db.csv", Encoding.UTF8, cancellationToken));
            foreach (var i in data["list"] as JArray)
            {
                string name = i.Value<string>("universityName");
                var u = await _unitOfWork.UniversityData.GetByFilterAsync(c =>
                    c.InstitutionName == name, 0, 1, cancellationToken);
                
                if (u.Count == 0)
                    continue;
                var university = u.FirstOrDefault();
                var apiId = i.Value<string>("id");
                HttpClient client = new HttpClient();
                var res = await client.GetAsync($"https://aplikacje.edukacja.gov.pl/api/internal-data-hub/public/opi/university/{apiId}/course", cancellationToken);
                
                dynamic courses = JsonConvert.DeserializeObject(await res.Content.ReadAsStringAsync(cancellationToken));
                foreach (var a in courses["list"] as JArray)
                {
                    var x = new DegreeCourse()
                    {
                        Name = a.Value<string>("name"),
                        UniversityId = university.Id,
                        Description = "",
                        Rate = 0,
                        RateCount = 0,
                        ModeOfStudy = a.Value<string>("formLabel") == "Niestacjonarne" ? ModeOfStudy.Remote : ModeOfStudy.Stationary,
                        Price = 0,
                        Id = Guid.NewGuid()
                    };
                    j++;
                    Console.WriteLine(j);
                    await _unitOfWork.DegreeCourses.AddAsync(x, cancellationToken);
                }
            }
            Console.WriteLine("abc " + it);
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

using System.Text;
using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.ValueObjects;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hackyeah.App.Application.Actions;

public static class GetMapLocalization
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

            int i = 0;
            foreach (var item in x)
            {
                HttpClient client = new HttpClient();
                string addressToMap = item.Name + " " + item.Voivodeship;
                var res = await client.GetAsync($"https://maps.google.com/maps/api/geocode/json?address={addressToMap}&key=AIzaSyB17h7tVIEnND8kQ14kbDT9JMGgIpSpthk", cancellationToken);
                

                JObject resXY = JsonConvert.DeserializeObject<JObject>(await res.Content.ReadAsStringAsync(cancellationToken));
                var Y = double.Parse(resXY["results"][0]["geometry"]["location"]["lat"].ToString());
                var X = double.Parse(resXY["results"][0]["geometry"]["location"]["lng"].ToString());
                
                item.X = X.ToString();
                item.Y = Y.ToString();
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                
                Console.WriteLine(i);
                i++;
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

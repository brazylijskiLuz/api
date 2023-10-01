using FluentValidation;
using hackyeah.App.Application.DataAccess;
using hackyeah.App.Domain.Entities;
using MediatR;

namespace hackyeah.App.Application.Actions.Data;

public static class GetByDegreeCourse
{
    public sealed record Command(string Name, int page) : IRequest<List<DegreeCourse>>;

    public class Handler : IRequestHandler<Command, List<DegreeCourse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private int _pageSize = 10;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<DegreeCourse>> Handle(Command request, CancellationToken cancellationToken) 
            => _unitOfWork.DegreeCourses.GetByNameAsync(request.Name, request.page, _pageSize, cancellationToken);

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}
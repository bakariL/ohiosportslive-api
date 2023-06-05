using GamesCore.ModelData.ResponseModels;
using MediatR;
using System;
using System.Linq;

namespace GamesCore.Services.Concrete.GameRequests
{
    public class GetUpcomingGamesRequest : IRequest<IQueryable<UpcomingGameResponse>>
    {
        public Guid GameId { get; set; }
    }
}

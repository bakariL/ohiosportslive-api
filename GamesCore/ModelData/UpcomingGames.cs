using HotChocolate.Types;
using System;

namespace GamesCore.ModelData
{
    public class UpcomingGames
    {
        public Guid GameId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Location { get; set; }
        public DateTimeOffset DateOfGame { get; set; }
        public string Description { get; set; }
        public decimal TicketPrice { get; set; }
    }

    public class UpcomingGamesType : ObjectType<UpcomingGames>
    {
        protected override void Configure(IObjectTypeDescriptor<UpcomingGames> descriptor)
        {
            descriptor.Field(p => p.GameId).Type<NonNullType<IdType>>();
            descriptor.Field(p => p.HomeTeam).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.AwayTeam).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Location).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.DateOfGame).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.Description).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.TicketPrice).Type<NonNullType<DecimalType>>();
        }
    }

}

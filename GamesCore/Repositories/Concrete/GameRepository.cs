
using GameCore.Repositories.Abstract;
using GamesCore.ModelData;
using GamesCore.ModelData.CoreContext;
using GamesCore.ModelData.Models;
using GamesCore.ModelData.ResponseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GameCore.Repositories.Concrete
{
    public class GameRepository : IGameRepository
    {

        public void CreateUpcomingGame(UpcomingGames upcomingGame)
        {
            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand(Constant.Game_Constants.ADD_UPCOMING_GAME, con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@HOME_TEAM", System.Data.SqlDbType.VarChar).Value = upcomingGame.HomeTeam;
                    cmd.Parameters.Add("@AWAY_TEAM", System.Data.SqlDbType.VarChar).Value = upcomingGame.AwayTeam;
                    cmd.Parameters.Add("@GAME_DATE", System.Data.SqlDbType.DateTimeOffset).Value = upcomingGame.DateOfGame;
                    cmd.Parameters.Add("@Location", System.Data.SqlDbType.VarChar).Value = upcomingGame.Location;
                    cmd.Parameters.Add("@TICKET_PRICE", System.Data.SqlDbType.Money).Value = upcomingGame.TicketPrice;
                    //cmd.Parameters.Add("@DATE_OFGAME", System.Data.SqlDbType.VarChar).Value = upcomingGame.Date_of_Game;
                    cmd.ExecuteScalar();
                }
                con.Dispose();
            }
        }

        public void DeleteUpcomingGame(int upcomingGameId)
        {
            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand(Constant.Game_Constants.ADD_UPCOMING_GAME, con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GAMEID", System.Data.SqlDbType.Int).Value = upcomingGameId;
                    cmd.ExecuteScalar();
                    con.Dispose();

                }
            }
        }

        public UpcomingGames EditUpcomingGame(UpcomingGames upcomingGame)
        {
            UpcomingGames editedGame = new UpcomingGames();

            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new System.Data.DataTable();

                using (SqlCommand cmd = new SqlCommand(Constant.Game_Constants.ADD_UPCOMING_GAME, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@GAMEID", SqlDbType.Int).Value = upcomingGame.GameId;
                    cmd.Parameters.Add("@TEAM1", SqlDbType.Int).Value = upcomingGame.HomeTeam;
                    cmd.Parameters.Add("@TEAM2", SqlDbType.Int).Value = upcomingGame.AwayTeam;
                    cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = upcomingGame.Location;
                    //cmd.Parameters.Add("@DATE_OFGAME", SqlDbType.DateTime).Value = upcomingGame.Date_of_Game;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        editedGame.HomeTeam = row.Field<string>("HomeTeam");
                        editedGame.AwayTeam = row.Field<string>("AwayTeam2");
                        editedGame.Location = row.Field<string>("Location");
                        //editedGame.Date_of_Game = row.Field<DateTime>("Date_of_Game");
                    }

                    con.Dispose();
                }
                return editedGame;
            }
        }

        public Games GameIsCompleted(int gameId)
        {
            throw new NotImplementedException();
        }

        public Games MakeGameClassic(int gameId)
        {
            throw new NotImplementedException();
        }

        public GameData AcceptGame(Guid upcomingGameId, bool isAccepted)
        {
            GameData acceptedGame = new GameData();
            return acceptedGame;

        }


        public List<UpcomingGames> ViewAllUpcomingGamesData()
        {
            List<UpcomingGames> gameList = new List<UpcomingGames>();

            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Constant.Game_Constants.ALL_UPCOMING_GAMES, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        UpcomingGames game = new UpcomingGames();

                        game.HomeTeam = row.Field<string>("HomeTeam");
                        game.AwayTeam = row.Field<string>("AwayTeam");
                        game.Location = row.Field<string>("Location");
                        //game.ImgPath = row.Field<string>("Img_path");

                        gameList.Add(game);
                    }
                    con.Dispose();
                }


            }
            return gameList;
        }

        public GameData AcceptGame(int upcomingGameId, bool isAccepted)
        {
            GameData game = new GameData();

            using(SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();
                using(SqlCommand cmd = new SqlCommand(Constant.Game_Constants.ACCEPT_GAME))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GAMEID", SqlDbType.Int).Value = upcomingGameId;
                    cmd.Parameters.Add("@IsAccepted", SqlDbType.Bit).Value = isAccepted;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach(DataRow row in dt.Rows)
                    {
                        game.GameId= row.Field<Guid>("Id");
                        game.IsAccetped = row.Field<bool>("IsAccepted");
                    }
                }
            }

            return game;
        }

        public GameData ViewUpcomingGame(int upcomingGameId)
        {
            GameData game = new GameData();

            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();
                using(SqlCommand cmd = new SqlCommand(Constant.Game_Constants.VIEW_DETIALS_UPCOMING_GAMES, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@GAMEID", SqlDbType.Int).Value = upcomingGameId;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach(DataRow row in dt.Rows)
                    {
                        game.HomeTeam = row.Field<string>("HomeTeam");
                        game.GuestTeam = row.Field<string>("AwayTeam");
                        game.IsAccetped = row.Field<bool>("IsAccepted");
                    }


                }
            }
            return game;
        }

        public LiveGames WatchNow(int gameId)
        {
            throw new NotImplementedException();
        }

      

        public List<PreviousGames> ViewPreviousGames()
        {
            List<PreviousGames> gameList = new List<PreviousGames>();

            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Constant.Game_Constants.PREVIOUS_GAMES, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        PreviousGamesData game = new PreviousGamesData();
                        game.GameId = row.Field<Guid>("GameId");
                        game.HomeTeam = row.Field<string>("HomeTeam");
                        game.AwayTeam = row.Field<string>("AwayTeam");
                        game.Location = row.Field<string>("Location");
                        game.ImgPath = row.Field<string>("ImgPath");
                        gameList.Add(game);
                    }
                    con.Dispose();
                }
            }
            return gameList;
        }

        public List<AllGames> ViewAllGames()
        {
            List<AllGames> gameList = new List<AllGames>();

            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Constant.Game_Constants.ALL_GAMES, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        AllGamesData game = new AllGamesData();
                        game.Id = row.Field<Guid>("GameId");
                        game.HomeTeam = row.Field<string>("HomeTeam");
                        game.AwayTeam = row.Field<string>("AwayTeam");
                        game.Location = row.Field<string>("Location");
                        game.ImgPath = row.Field<string>("Img_path");

                        gameList.Add(game);
                    }
                    con.Dispose();
                }


            }
            return gameList;
        }

        Games IGameRepository.ViewUpcomingGame(int upcomingGameId)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingGamesData> ViewAllUpcomingGames()
        {
            List<UpcomingGamesData> gameList = new List<UpcomingGamesData>();

            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Constant.Game_Constants.ALL_UPCOMING_GAMES, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        UpcomingGamesData game = new UpcomingGamesData();
                        game.GameId = row.Field<Guid>("GameId");
                        game.HomeTeam = row.Field<string>("HOME_TEAM");
                        game.AwayTeam = row.Field<string>("GUEST_TEAM");
                        game.Location = row.Field<string>("LOCATION");
                        game.ImgPath = row.Field<string>("IMG_PATH");

                        gameList.Add(game);
                    }
                    con.Dispose();
                }


            }
            return gameList;
        }

        public List<TodaysGames> ViewTodaysGames()
        {
            List<TodaysGames> gameList = new List<TodaysGames>();

            using (SqlConnection con = new SqlConnection(Constant.Game_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Constant.Game_Constants.TODAYS_GAMES, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        TodaysGames game = new TodaysGames();
                        game.GameId = row.Field<Guid>("GameId");
                        game.HomeTeam = row.Field<string>("HomeTeam");
                        game.AwayTeam = row.Field<string>("AwayTeam");
                        game.StartTime = row.Field<string>("StartTime");
                        game.Description = row.Field<string>("Description");

                        gameList.Add(game);
                    }
                    con.Dispose();
                }


            }
            return gameList;
        }

        public List<PreviousGamesData> ViewPreviousGamesData()
        {
            throw new NotImplementedException();
        }

   
    }
}

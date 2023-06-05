using System.Data.SqlClient;
using PlayersCore.ModelData;
using PlayersCore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersCore.Constant;

namespace PlayersCore.Repositories.Concrete
{
    public class PlayersRepository : IPlayersRepository
    {

        public void AddPlayer(Players player)
        {
            using (SqlConnection con = new SqlConnection(Player_Constants.CONNECTION_STRING_FLUX))
            {
                SqlCommand cmd = new SqlCommand(Player_Constants.ADD_NEW_PLAYER, con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = player.FirstName;
                cmd.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = player.LastName;
                cmd.Parameters.Add("@TEAMID", SqlDbType.Int).Value = 55;
                cmd.Parameters.Add("@SCHOOL", SqlDbType.VarChar).Value = player.School;
                cmd.Parameters.Add("@GRADUATION_YR", SqlDbType.Int).Value = 2020;
                cmd.Parameters.Add("@SPORT", SqlDbType.VarChar).Value = player.Sport;
                cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = player.City;
                cmd.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@IGNAME", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@TWITTERNAME", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@POSITIONS", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@HEIGHT", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@WEIGHT", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@PPG", SqlDbType.Decimal).Value = 2.00;
                cmd.Parameters.Add("@RPG", SqlDbType.Decimal).Value = 2.00;
                cmd.Parameters.Add("@APG", SqlDbType.Decimal).Value = 2.00;
                cmd.Parameters.Add("@SPG", SqlDbType.Decimal).Value = 2.00;
                cmd.Parameters.Add("@BPG", SqlDbType.Decimal).Value = 2.00;
                cmd.Parameters.Add("@FUNFACT_1", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@FUNFACT_2", SqlDbType.VarChar).Value = "";
                cmd.ExecuteScalar();
                con.Dispose();
                cmd.Dispose();
            }
        }


        //DELETE PLAYER
        public void DeletePlayer(int playerId)
        {
            using (SqlConnection con = new SqlConnection(Player_Constants.CONNECTION_STRING_FLUX))
            {
                using(SqlCommand cmd = new SqlCommand(Player_Constants.DELETE_PLAYER, con))
                {
                    con.Open();
                    cmd.Parameters.Add("@PLAYERID", SqlDbType.Int).Value = playerId;
                    cmd.ExecuteScalar();
                    con.Dispose();
                    //cmd.Dispose();
                }
                
            }
        }

        //EDIT
        public Players EditPlayer(Players player)
        {
            Players editPlayer = new Players();

            using (SqlConnection con = new SqlConnection(Player_Constants.CONNECTION_STRING_FLUX))
            {              
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Player_Constants.EDIT_PLAYER,con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = player.FirstName;
                    cmd.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = player.LastName;
                    cmd.Parameters.Add("@TEAMID", SqlDbType.Int).Value = 55;
                    cmd.Parameters.Add("@SCHOOL", SqlDbType.VarChar).Value = player.School;
                    cmd.Parameters.Add("@GRADUATION_YR", SqlDbType.Int).Value = 2020;
                    cmd.Parameters.Add("@SPORT", SqlDbType.VarChar).Value = player.Sport;
                    cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = player.City;
                    cmd.Parameters.Add("@STATE", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@IGNAME", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@TWITTERNAME", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@POSITIONS", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@HEIGHT", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@WEIGHT", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("@PPG", SqlDbType.Decimal).Value = 2.00;
                    cmd.Parameters.Add("@RPG", SqlDbType.Decimal).Value = 2.00;
                    cmd.Parameters.Add("@APG", SqlDbType.Decimal).Value = 2.00;
                    cmd.Parameters.Add("@SPG", SqlDbType.Decimal).Value = 2.00;
                    cmd.Parameters.Add("@BPG", SqlDbType.Decimal).Value = 2.00;
                    cmd.Parameters.Add("@FUNFACT_1", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@FUNFACT_2", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@PlayerID", SqlDbType.Int).Value = 2;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);               
                    
                    foreach(DataRow row in dt.Rows)
                    {
                        editPlayer.FirstName = row.Field<string>("FIRST_NAME");
                        editPlayer.LastName = row.Field<string>("LAST_NAME");
                        editPlayer.School = row.Field<string>("SCHOOL");
                        editPlayer.Sport = row.Field<string>("SPORT");
                        editPlayer.City = row.Field<string>("CITY");
                        editPlayer.PointPerGame = row.Field<decimal>("POINTS_PER_GAME");
                    }
                    //cmd.Dispose();
                }        
                con.Dispose();
            }
            return editPlayer;
        }




        //view single player
        public Players GetPlayer(int playerId)
        {
            Players player = new Players();

            using (SqlConnection con = new SqlConnection(Player_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Player_Constants.SELECT_A_PLAYER, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PLAYERID", SqlDbType.Int).Value = playerId;
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        player.FirstName = row.Field<string>("FIRST_NAME");
                        player.LastName = row.Field<string>("LAST_NAME");
                        player.School = row.Field<string>("SCHOOL");
                        player.Sport = row.Field<string>("SPORT");
                        player.City = row.Field<string>("CITY");
                        player.State = row.Field<string>("STATE");
                        player.PointPerGame = row.Field<decimal>("POINTS_PER_GAME");
                    }
                    //cmd.Dispose();
                }
                con.Dispose();
            }
            return player;
        }



        public Players SerachForPlayer(string searchText)
        {
            throw new NotImplementedException();
        }

        public List<Players> ViewAllPlayers()
        {
            List<Players> listPlayer = new List<Players>();

            using (SqlConnection con = new SqlConnection(Player_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Player_Constants.SELECT_A_PLAYER, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.ExecuteNonQuery();
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //da.Fill(dt);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var player = new Players();
                            player.FirstName = reader["FULL_NAME"].ToString();
                            player.School = reader["SCHOOL"].ToString();
                            player.Sport = reader["SPORT"].ToString();
                            player.City = reader["CITY"].ToString();
                            player.GraduationYear = reader["GRAUATION_YEAR"].ToString();
                            listPlayer.Add(player);
                        }
                    }
                    //cmd.Dispose();
                }
                con.Dispose();
            }
            return listPlayer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsCore.Constant;
using TeamsCore.ModelData;
using TeamsCore.Repositories.Abstract;

namespace TeamsCore.Repositories.Concrete
{
    public class TeamRepository : ITeamRepository
    {
        public void CreateTeam(Team team)
        {
            using(SqlConnection con = new SqlConnection(Teams_Constants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand(Teams_Constants.ADD_NEW_Team, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = team.TeamName;
                    //cmd.Parameters.Add("@MASCOT", SqlDbType.VarChar).Value = team.MASCOT;
                    cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = team.City;
                    cmd.Parameters.Add("@STATE", SqlDbType.VarChar).Value = team.State;
                    cmd.Parameters.Add("@HC_NAME", SqlDbType.VarChar).Value = team.HeadCoachName;
                    //cmd.Parameters.Add("@WINS", SqlDbType.Int).Value = team.WINS;
                    //cmd.Parameters.Add("@LOSSES", SqlDbType.Int).Value = team.LOSSES;
                    //cmd.Parameters.Add("@CONFERENCENAME", SqlDbType.VarChar).Value = team.CONFERENCE_NAME;
                    //cmd.Parameters.Add("@CONFERENCE_RANKING", SqlDbType.Int).Value = team.CONFERENCE_RANKING;
                    //cmd.Parameters.Add("@STATERANKING", SqlDbType.Int).Value = team.STATE_RANKING;
                    //cmd.Parameters.Add("@AREARANKING", SqlDbType.Int).Value = team.AREA_RANKING;
                    //cmd.Parameters.Add("@UPCOMING_GAME", SqlDbType.VarChar).Value = team.UPCOMING_GAME;
                    //cmd.Parameters.Add("@IGname", SqlDbType.NVarChar).Value = team.IG_NAME;
                    //cmd.Parameters.Add("@TWITTERNAME", SqlDbType.NVarChar).Value = team.TWITTER_NAME;
                    //cmd.Parameters.Add("@InGAME", SqlDbType.Bit).Value = team.InGAME;
                    //cmd.Parameters.Add("@SEASONPASS", SqlDbType.Bit).Value = team.SEASONPASS;
                    //cmd.Parameters.Add("@GAME_PER_GAME_PAY", SqlDbType.Bit).Value = team.PAYPERGAME;
                    cmd.ExecuteScalar();
                    con.Dispose();
                }
            }
        }

        public void DeleteTeam(int teamId)
        {
           using(SqlConnection con = new SqlConnection(Teams_Constants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TEAMid", SqlDbType.Int).Value = teamId;
                    cmd.ExecuteScalar();
                    con.Dispose();
                }
            }
        }

        public Team EditTeam(Team team)
        {
            Team editedTeam = new Team();

            using(SqlConnection con = new SqlConnection(Teams_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using(SqlCommand cmd = new SqlCommand(Teams_Constants.EDIT_TEAM,con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NAME", SqlDbType.Int).Value = team.TeamName;
                    //cmd.Parameters.Add("@MASCOT", SqlDbType.VarChar).Value = team.MASCOT;
                    //cmd.Parameters.Add("@CITY", SqlDbType.VarChar).Value = team.CITY;
                    //cmd.Parameters.Add("@STATE", SqlDbType.VarChar).Value = team.STATE;
                    //cmd.Parameters.Add("@HC_NAME", SqlDbType.VarChar).Value = team.HEAD_COACH_NAME;
                    //cmd.Parameters.Add("@WINS", SqlDbType.Int).Value = team.WINS;
                    //cmd.Parameters.Add("@LOSSES", SqlDbType.Int).Value = team.LOSSES;
                    //cmd.Parameters.Add("@CONFERENCENAME", SqlDbType.VarChar).Value = team.CONFERENCE_NAME;
                    //cmd.Parameters.Add("@CONFERENCE_RANKING", SqlDbType.Int).Value = team.CONFERENCE_RANKING;
                    //cmd.Parameters.Add("@STATERANKING", SqlDbType.Int).Value = team.STATE_RANKING;
                    //cmd.Parameters.Add("@AREARANKING", SqlDbType.Int).Value = team.AREA_RANKING;
                    //cmd.Parameters.Add("@UPCOMING_GAME", SqlDbType.VarChar).Value = team.UPCOMING_GAME;
                    //cmd.Parameters.Add("@IGname", SqlDbType.NVarChar).Value = team.IG_NAME;
                    //cmd.Parameters.Add("@TWITTERNAME", SqlDbType.NVarChar).Value = team.TWITTER_NAME;
                    //cmd.Parameters.Add("@InGAME", SqlDbType.Bit).Value = team.IG_NAME;
                    //cmd.Parameters.Add("@SEASONPASS", SqlDbType.Bit).Value = team.SEASONPASS;
                    //cmd.Parameters.Add("@GAME_PER_GAME_PAY", SqlDbType.Bit).Value = team.PAYPERGAME;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach(DataRow row in dt.Rows)
                    {
                        editedTeam.TeamName = row.Field<string>("TEAM_NAME");
                        //editedTeam.CITY = row.Field<string>("CITY");
                        //editedTeam.STATE = row.Field<string>("STATE");
                        //editedTeam.HEAD_COACH_NAME = row.Field<string>("HEAD_COACH_NAME");
                        //editedTeam.WINS = row.Field<int>("WINS");
                        //editedTeam.LOSSES = row.Field<int>("LOSSES");
                    }
                }
                con.Dispose();
            }
            return editedTeam;
        }

        public Team SelectTeam(int teamId)
        {
            Team team = new Team();

            using(SqlConnection con = new SqlConnection(Teams_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using(SqlCommand cmd = new SqlCommand(Teams_Constants.SELECT_A_TEAM,con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TEAMid", SqlDbType.Int).Value = teamId;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.Fill(dt);

                    foreach(DataRow row in dt.Rows)
                    {
                        team.TeamName = row.Field<string>("TEAM_NAME");
                        //team.MASCOT = row.Field<string>("MASCOT");
                        //team.CITY = row.Field<string>("CITY");
                        //team.STATE = row.Field<string>("STATE");
                        //team.WINS = row.Field<int>("WINS");
                        //team.LOSSES = row.Field<int>("LOSSES");
                        //team.HEAD_COACH_NAME = row.Field<string>("HEAD_COACH_NAME");
                        //team.CONFERENCE_NAME = row.Field<string>("CONFERENCE_NAME");
                        //team.CONFERENCE_RANKING = row.Field<int>("CONFERENCE_RANKING");
                    }
                }
                con.Dispose();
            }
            return team;
        }

        public List<Team> ViewAllTeams()
        {
            throw new NotImplementedException();
        }
    }
}

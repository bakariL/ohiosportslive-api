using AuthCore.Constant;
using AuthCore.Models;
using AuthCore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Repositories.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        public void DeleteUserAccount(UserModel user)
        {
            using (SqlConnection con = new SqlConnection(Auth_Constants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand(Auth_Constants.DELETE_USER, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user.UserName;
                    cmd.ExecuteScalar();
                    con.Dispose();
                }
            }
        }

        public UserModel GetUser(UserModel user)
        {
            UserModel _user = new UserModel();
            using (SqlConnection con = new SqlConnection(Auth_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Auth_Constants.GET_USER, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.Fill(dt);

                    foreach(DataRow row in dt.Rows)
                    {
                        _user.UserName = row.Field<string>("UserName");
                    }
                }
            }
            return _user;
        }

        public UserModel GetUserbyName(string name)
        {
            UserModel _user = new UserModel();
            using (SqlConnection con = new SqlConnection(Auth_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();

                using (SqlCommand cmd = new SqlCommand(Auth_Constants.GET_USER, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = name;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        _user.UserName = row.Field<string>("UserName");
                        _user.Email = row.Field<string>("EMAIL_ADDRESS");
                        _user.IsLogedin = row.Field<bool>("IsLoggedIn");
                    }
                }
            }
            return _user;
        }

        public bool IsUserActive(string name)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(Auth_Constants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand(Auth_Constants.IS_USER_VALID, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@Email_Address", SqlDbType.NVarChar).Value = name;
                    var res = cmd.ExecuteScalar();
                    if (res.Equals(true))
                        result = true;
                                
                }
                con.Dispose();
                return result;

            }
            

        }

        public bool IsUserValid(string username, string pw, string email)
        {
            using (SqlConnection con = new SqlConnection(Auth_Constants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand(Auth_Constants.IS_USER_VALID, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pw;
                    cmd.Parameters.Add("@Email_Address", SqlDbType.NVarChar).Value = email;
                    var res = cmd.ExecuteScalar();

                    if (res.Equals(true))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public UserModel Login(LoginModel login)
        {
            UserModel user = new UserModel();
            using (SqlConnection con = new SqlConnection(Auth_Constants.CONNECTION_STRING_FLUX))
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(Auth_Constants.USER_LOGIN, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = login.UserName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = login.Email_Address;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = login.Password;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        user.UserName = row.Field<string>("username");
                        //user.Name = row.Field<string>("Name");
                    }
                }
                con.Dispose();
                //var isActive = IsUserActive(user.UserName);
                //if(isActive != true)
                //{
                //    throw new NotImplementedException();
                //}
            }
            return user;
        }

        public void Register(RegistrationModel newUser)
        {
            using (SqlConnection con = new SqlConnection(Auth_Constants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand(Auth_Constants.ADD_USER, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = newUser.Name;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = newUser.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = newUser.Password;
                    cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = newUser.Token; 
                    cmd.Parameters.Add("@CustId", SqlDbType.NVarChar).Value = newUser.CustId;
                    cmd.ExecuteScalar();
                    con.Dispose();
                }
            }
        }

        public void SignOut(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}

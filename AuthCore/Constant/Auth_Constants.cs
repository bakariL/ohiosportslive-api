using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Constant
{
    public class Auth_Constants
    {
        public static string CONNECTION_STRING_FLUX = "Data Source=DESKTOP-50PJ1J0; Initial Catalog=FluxLive; Integrated Security=True";
        public static string DELETE_USER = "";
        public static string ADD_USER = "SP_ADD_USER";
        public static string EDIT_USER = "";
        public static string USER_LOGIN = "SP_LOGIN";
        public static string USER_SIGNOUT = "";
        public static string GET_USER = "SP_GET_USER";
        public static string IS_USER_VALID = "SP_CHECK_USER_VALIDATION";
        public static string IS_USER_loggedin = "SP_IS_USER_LOGGED_IN";

    }
}

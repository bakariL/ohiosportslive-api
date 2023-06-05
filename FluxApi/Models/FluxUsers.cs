using System.ComponentModel.DataAnnotations.Schema;

namespace FluxApi.Models
{
   
    public class FluxUsers
    {
        public int Id { get; set; }
        public string Cust_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email_Address { get; set; }
        public int Phone_Number { get; set; }
        public int Zip_Code { get; set; }
        public bool IsMember { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPaidAnnually { get; set; }
        public string Api_Key { get; set; }
        public string Token { get; set; }
        public string Additional_Information { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}

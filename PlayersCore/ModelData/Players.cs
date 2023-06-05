using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersCore.ModelData
{
    public class Players
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int TeamId { get; set; }
        public string School { get; set; }
        public string GraduationYear { get; set; }
        public string Sport { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string IgName { get; set; }
        public string TwitterName { get; set; }
        public string Positions { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public decimal PointPerGame { get; set; }
        public decimal ReboundsPerGame { get; set; }
        public decimal AssistPerGame { get; set; }
        public decimal StealsPerGame { get; set; }
        public decimal BlocksPerGame { get; set; }
    }
}

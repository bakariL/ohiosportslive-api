using FluxFileManagerCore.ModelData.Models;
using FluxFileManagerCore.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FluxFileManagerCore.Repositories.Concrete
{
    public class FluxFileManagerRepository : IFluxFileManagerRepository
    {
        public Guid AddNewFluxImage(NewUploadFile file)
        {
            Guid gameId = Guid.NewGuid();

            using (SqlConnection con = new SqlConnection(Constant.FluxFileMangementConstants.CONNECTION_STRING_FLUX))
            {
                using (SqlCommand cmd = new SqlCommand(Constant.FluxFileMangementConstants.UPLOAD_NEW_FLUX_IMAGE, con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UUID", System.Data.SqlDbType.UniqueIdentifier).Value = file.Uuid;
                    cmd.Parameters.Add("@CDNURL", System.Data.SqlDbType.NVarChar).Value = file.CdnUrl;
                    cmd.Parameters.Add("@NAME", System.Data.SqlDbType.NVarChar).Value = file.Name;
                    cmd.Parameters.Add("@SIZE", System.Data.SqlDbType.VarChar).Value = file.Size;
                    cmd.Parameters.Add("@ISSTORED", System.Data.SqlDbType.VarChar).Value = file.IsStored;
                    cmd.Parameters.Add("@ISIMAGE", System.Data.SqlDbType.VarChar).Value = file.IsImage;
                    cmd.Parameters.Add("@GAMEID", System.Data.SqlDbType.UniqueIdentifier).Value = gameId;
                    cmd.ExecuteScalar();
                }
                con.Dispose();
            }
            return gameId;
        }

        public void DeleteFluxImage(Guid id)
        {
            throw new NotImplementedException();
        }

        public NewUploadFile GetFluxImage(Guid id)
        {
            throw new NotImplementedException();
        }

        public NewUploadFile UpdateFluxImage(NewUploadFile file)
        {
            throw new NotImplementedException();
        }
    }
}

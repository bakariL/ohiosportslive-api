using FluxFileManagerCore.ModelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxFileManagerCore.Repositories.Abstract
{
    public interface IFluxFileManagerRepository
    {
        Guid AddNewFluxImage(NewUploadFile file);
        void DeleteFluxImage(Guid id);
        NewUploadFile UpdateFluxImage(NewUploadFile file);
        NewUploadFile GetFluxImage(Guid id);
    }
}

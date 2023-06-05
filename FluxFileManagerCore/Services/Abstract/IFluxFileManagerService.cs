using FluxFileManagerCore.ModelData.Models;

namespace FluxFileManagerCore.Services.Abstract
{
    public interface IFluxFileManagerService
    {
        Guid AddNewFluxImage(NewUploadFile file);
        void DeleteFluxImage(Guid id);
        NewUploadFile UpdateFluxImage(NewUploadFile file);
        NewUploadFile GetFluxImage(Guid id);
    }
}

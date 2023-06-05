using FluxFileManagerCore.ModelData.Models;
using FluxFileManagerCore.Services.Abstract;
using FluxFileManagerCore.Repositories.Abstract;

namespace FluxFileManagerCore.Services.Concrete
{
    public class FluxFileManagerService : IFluxFileManagerService
    {
        private readonly IFluxFileManagerRepository _fluxFileManagerRepository;

        public FluxFileManagerService(IFluxFileManagerRepository fluxFileManagerRepository)
        {
            _fluxFileManagerRepository = fluxFileManagerRepository; 
        }
        public Guid AddNewFluxImage(NewUploadFile file)
        {
           return _fluxFileManagerRepository.AddNewFluxImage(file);
        }

        public void DeleteFluxImage(Guid id)
        {
            _fluxFileManagerRepository.DeleteFluxImage(id);
        }

        public NewUploadFile GetFluxImage(Guid id)
        {
           return _fluxFileManagerRepository.GetFluxImage(id);
        }

        public NewUploadFile UpdateFluxImage(NewUploadFile file)
        {
            return _fluxFileManagerRepository.UpdateFluxImage(file);
        }
    }
}

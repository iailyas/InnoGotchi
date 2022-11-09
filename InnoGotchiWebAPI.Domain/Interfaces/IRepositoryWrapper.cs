using InnoGotchiWebAPI.Domain.Interfaces.Repositories;

namespace InnoGotchiWebAPI.Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        IPetRepository PetRepository { get; }
        ILookRepository LookRepository { get; }
        IFarmRepository FarmRepository { get; }
        ICollaborationRepository CollaborationRepository { get; }
        ICharacteristicRepository CharacteristicRepository { get; }

        void Save();
    }
}

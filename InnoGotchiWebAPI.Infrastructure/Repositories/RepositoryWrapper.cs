using InnoGotchiWebAPI.Domain.Interfaces;
using InnoGotchiWebAPI.Domain.Interfaces.Repositories;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MainDbContext mainDbContext;
        private IUserRepository userRepository;
        private IPetRepository petRepository;
        private ILookRepository lookRepository;
        private IFarmRepository farmRepository;
        private ICollaborationRepository collaborationRepository;
        private ICharacteristicRepository characteristicRepository;

        public RepositoryWrapper(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(mainDbContext);
                }
                return this.userRepository;
            }
        }

        public IPetRepository PetRepository
        {
            get
            {
                if (this.petRepository == null)
                {
                    this.petRepository = new PetRepository(mainDbContext);
                }
                return this.petRepository;
            }
        }

        public ILookRepository LookRepository
        {
            get
            {
                if (this.lookRepository == null)
                {
                    this.lookRepository = new LookRepository(mainDbContext);
                }
                return this.lookRepository;
            }
        }

        public IFarmRepository FarmRepository
        {
            get
            {
                if (this.farmRepository == null)
                {
                    this.farmRepository = new FarmRepository(mainDbContext);
                }
                return this.farmRepository;
            }
        }

        public ICollaborationRepository CollaborationRepository
        {
            get
            {
                if (this.collaborationRepository == null)
                {
                    this.collaborationRepository = new CollaborationRepository(mainDbContext);
                }
                return this.collaborationRepository;
            }
        }

        public ICharacteristicRepository CharacteristicRepository
        {
            get
            {
                if (this.characteristicRepository == null)
                {
                    this.characteristicRepository = new CharacteristicRepository(mainDbContext);
                }
                return this.characteristicRepository;
            }
        }

        public void Save()
        {
            mainDbContext.SaveChanges();
        }
    }
}

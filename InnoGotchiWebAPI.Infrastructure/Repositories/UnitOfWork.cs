//using InnoGotchiWebAPI.Domain.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.PortableExecutable;
//using System.Text;
//using System.Threading.Tasks;

//namespace InnoGotchiWebAPI.Infrastructure.Repositories
//{
//    public class UnitOfWork : IDisposable
//    {
//        private MainDbContext mainDbContext;
//        private RepositoryBase<Farm> farmRepository;
//        private RepositoryBase<Characteristic> characteristicRepository;
//        private RepositoryBase<Collaboration> collaborationRepository; 
//        private RepositoryBase<Look> lookRepository;
//        private RepositoryBase<Pet> petRepository;
//        private RepositoryBase<User> userRepository;

//        public RepositoryBase<Farm> FarmRepository
//        {
//            get 
//            {
//                if (this.farmRepository == null)
//                {
//                    this.farmRepository = new RepositoryBase<Farm>(mainDbContext);
//                }
//                return this.farmRepository;
//            }
//        }
//        public RepositoryBase<Characteristic> CharacteristicRepository
//        {
//            get
//            {
//                if (this.characteristicRepository == null)
//                {
//                    this.characteristicRepository = new RepositoryBase<Characteristic>(mainDbContext);
//                }
//                return this.characteristicRepository;
//            }
//        }
//        public RepositoryBase<Collaboration> CollaborationRepository
//        {
//            get
//            {
//                if (this.collaborationRepository == null)
//                {
//                    this.collaborationRepository = new RepositoryBase<Collaboration>(mainDbContext);
//                }
//                return this.collaborationRepository;
//            }
//        }
//        public RepositoryBase<Look> LookRepository
//        {
//            get
//            {
//                if (this.lookRepository == null)
//                {
//                    this.lookRepository = new RepositoryBase<Look>(mainDbContext);
//                }
//                return this.lookRepository;
//            }
//        }

//        public RepositoryBase<Pet> PetRepository
//        {
//            get
//            {
//                if (this.petRepository == null)
//                {
//                    this.petRepository = new RepositoryBase<Pet>(mainDbContext);
//                }
//                return this.petRepository;
//            }
//        }
//        public RepositoryBase<User> UserRepository
//        {
//            get
//            {
//                if (this.userRepository == null)
//                {
//                    this.userRepository = new RepositoryBase<User>(mainDbContext);
//                }
//                return this.userRepository;
//            }
//        }
//        public void Save()
//        {
//            mainDbContext.SaveChanges();
//        }
//        private bool disposed = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    mainDbContext.Dispose();
//                }
//            }
//            this.disposed = true;
//        }
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//    }
//}

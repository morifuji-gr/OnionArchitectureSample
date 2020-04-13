using System.Threading.Tasks;
using onion.Domain;

namespace onion.Application
{
    public class SaveDataService
    {
        private readonly ISaveDataRepository _saveDataRepository;

        public SaveDataService(ISaveDataRepository saveDataRepository)
        {
            _saveDataRepository = saveDataRepository;
        }

        public Task <SaveData> FindAsync(string key) => _saveDataRepository.FindAsync(key);
        public Task            StoreAsync(string key, SaveData saveData) => _saveDataRepository.StoreAsync(key, saveData);
    }
}
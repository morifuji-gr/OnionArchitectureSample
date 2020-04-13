using onion.Domain;
using UnityEngine;
using System.Threading.Tasks;

namespace onion.Infrastructure
{
    public class PlayerPrefsSaveDataRepository : ISaveDataRepository
    {
        private readonly string _nameKey   = "name.";
        private readonly string _powerKey  = "power.";
        private readonly string _speedKey  = "speed.";
        private readonly string _healthKey = "health.";

        #pragma warning disable CS1998
        public async Task <SaveData> FindAsync(string key)
        #pragma warning restore CS1998
        {
            var name = PlayerPrefs.GetString(_nameKey + key, "");
            if (string.IsNullOrEmpty(name)) { return null; }
            var power  = PlayerPrefs.GetInt(_powerKey + key, 0);
            var speed  = PlayerPrefs.GetInt(_speedKey + key, 0);
            var health = PlayerPrefs.GetInt(_healthKey + key, 0);

            return new SaveData(name, power, speed, health);
        }

        #pragma warning disable CS1998
        public async Task StoreAsync(string key, SaveData saveData)
        #pragma warning restore CS1998
        {
            PlayerPrefs.SetString(_nameKey + key, saveData.Name);
            PlayerPrefs.SetInt(_powerKey + key, saveData.Power);
            PlayerPrefs.SetInt(_speedKey + key, saveData.Speed);
            PlayerPrefs.SetInt(_healthKey + key, saveData.Health);
            PlayerPrefs.Save();
        }
    }
}

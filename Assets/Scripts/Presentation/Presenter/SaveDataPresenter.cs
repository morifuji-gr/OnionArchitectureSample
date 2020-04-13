using onion.Domain;
using onion.Presentation.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UniRx.Async;

namespace onion.Presentation.Presenter
{
    public class SaveDataPresenter : MonoBehaviour
    {
        [Inject] private SaveDataManager _saveDataManager;
        [SerializeField] private InputField _nameInputField;
        [SerializeField] private InputField _powerInputField;
        [SerializeField] private InputField _speedInputField;
        [SerializeField] private InputField _healthInputField;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;

        private void Start()
        {
            _saveDataManager.CurrentSaveData
            .Where(x => x != null)
            .Subscribe(x =>
            {
                _nameInputField.text   = x.Name;
                _powerInputField.text  = x.Power.ToString();
                _speedInputField.text  = x.Speed.ToString();
                _healthInputField.text = x.Health.ToString();
            });

            _saveButton.BindToOnClick(_ =>
            {
                var power  = int.Parse(_powerInputField.text);
                var speed  = int.Parse(_speedInputField.text);
                var health = int.Parse(_healthInputField.text);
                var name   = new SaveData(_nameInputField.text, power, speed, health);

                return _saveDataManager.SaveAsync(name).ToObservable().AsUnitObservable();
            });

            _loadButton.BindToOnClick(_ => _saveDataManager.LoadAsync().ToObservable().AsUnitObservable());
        }
    }
}

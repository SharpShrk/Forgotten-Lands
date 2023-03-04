using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthImprove _healthImprove;
    [SerializeField] private ArmorImprove _armorImprove;

    private PlayerMover _mover;
    private float _currentHealth;
    private float _startMaxHealth;
    private float _armor;
    private float _startArmor = 0;
   
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    public event UnityAction<float, float> HealthChanged;   
    
    public event UnityAction GameOver;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _currentHealth = _maxHealth;
        _startMaxHealth = _maxHealth;
        _armor = _startArmor;      
    }

    public void Restart()
    {
        _armor = _startArmor + _armorImprove.ArmorBonus;

        _maxHealth = _startMaxHealth + _healthImprove.HealthBonus;
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        _mover.PlaceInCenter();
        _mover.TakeSpeedImprove();
    }

    public void ApplyDamage(float damage)
    {
        bool _isIgnoreDamage = TryIgnoreDamage(_armor);

        if(_isIgnoreDamage == false)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0)
            {
                GameOver?.Invoke();
            }
        }        
    }

    private bool TryIgnoreDamage(float armor)
    {
        float minChanceIgnore = 0;
        float maxChanceIgnore = 100;
        float chanseIgnore;

        chanseIgnore = Random.Range(minChanceIgnore, maxChanceIgnore);
        
        return chanseIgnore < armor;
    }
}

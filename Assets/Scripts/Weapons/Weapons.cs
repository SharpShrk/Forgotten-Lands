using UnityEngine;
using TMPro;
using UnityEngine.Events;

public abstract class Weapons : MonoBehaviour
{
    [SerializeField] protected string _label;
    [SerializeField] protected int _level;
    [SerializeField] protected int _id;
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected bool _isEquipped = false;
    [SerializeField] private TMP_Text _levelUI;

    private Vector2 _mousePosition;
    private PlayerInput _input;
    private int _maxLevel = 5;

    public event UnityAction WeaponEquiped;

    public string Label => _label;
    public int Level => _level;
    public int ID => _id;
    public Sprite Icon => _icon;
    public bool IsEquipped => _isEquipped;
    public int MaxLevel => _maxLevel;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Enable();
        _isEquipped = false;
    }

    public void Restart()
    {
        _level = 0;
        _levelUI.text = _level.ToString();
        _isEquipped = false;
    }

    public void LevelUp()
    {
        if (_isEquipped == false)
        {
            _isEquipped = true;
            WeaponEquiped?.Invoke();
        }

        _level++;
        _levelUI.text = _level.ToString();
    }
   
    protected void RotateShootPoint()
    {
        _mousePosition = _input.Player.MousePosition.ReadValue<Vector2>();
        Vector3 difference = Camera.main.ScreenToWorldPoint(_mousePosition) - transform.position;
        difference.Normalize();
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }
}

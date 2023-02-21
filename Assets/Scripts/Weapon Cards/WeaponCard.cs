using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Card", menuName = "Weapon card/Create new card", order = 51)]
public class WeaponCard : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _level;
    [SerializeField] private string _label;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;

    public int ID => _id;
    public int Level => _level;
    public string Label => _label;
    public string Description => _description;
    public Sprite Icon => _icon;
}

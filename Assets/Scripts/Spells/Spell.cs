using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private SpellType _type;
    [SerializeField] private int _value;

    public SpellType Type => _type;
    public int Value => _value;

    public enum SpellType
    {
        Wound,
        Heal
    }
}

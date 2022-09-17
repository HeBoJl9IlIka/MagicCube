using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Spell))]
public class ButtonSelectingSpell : EventTrigger
{
    private Spell _spell;

    public event UnityAction<Spell> Pressed;

    private void Start()
    {
        _spell = GetComponent<Spell>();
    }

    public override void OnPointerClick(PointerEventData data)
    {
        Pressed?.Invoke(_spell);
    }
}

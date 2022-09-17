using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GettingTumba))]
public class ButtonTumbaSpawning : EventTrigger
{
    private GettingTumba _gettingTumba;
    private Tumba _tumba;

    public event UnityAction Pressed;

    private void Start()
    {
        _gettingTumba = GetComponent<GettingTumba>();
        _tumba = _gettingTumba.Tumba;
    }

    public override void OnPointerClick(PointerEventData data)
    {
        Pressed?.Invoke();
        _tumba.gameObject.SetActive(true);
    }
}

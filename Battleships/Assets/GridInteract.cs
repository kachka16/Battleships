using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ShipGrid))]
public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    FieldController fieldController;
    ShipGrid shipGrid;
    private void Awake()
    {
        fieldController = FindFirstObjectByType<FieldController>();
        shipGrid = GetComponent<ShipGrid>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        fieldController.selectedShipGrid = shipGrid;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        fieldController.selectedShipGrid = null;
    }
    
}

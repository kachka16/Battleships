using UnityEngine;

public class FieldController : MonoBehaviour
{

    public ShipGrid selectedShipGrid;
    private void Update()
    {
        if(selectedShipGrid == null) { return; }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(selectedShipGrid.GetTileGridPosition(Input.mousePosition));
        }
    }
}

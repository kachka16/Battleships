using UnityEngine;

public class ShipUnit : MonoBehaviour, IUnit
{
  
    public Vector3 GetPosition()
    {
        return transform.localPosition;
    }

    public void SetPosition(Vector3 position)
    {
        transform.localPosition = position;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class FieldShip : MonoBehaviour
{
    public Vector3 GetPosition()
    {
        return GetComponent<RectTransform>().localPosition;
    }

    public void SetPosition(Vector3 position)
    {
        GetComponent<RectTransform>().localPosition = position;
    }



    public ShipData shipData;
    public int HEIGHT
    {
        get
        {
            if(rotated == false)
            {
                return shipData.height;
            }
            return shipData.width;
        }
    }
    public int WIDTH
    {
        get
        {
            if (rotated == false)
            {
                return shipData.width;
            }
            return shipData.height;
        }
    }

    public int onGridPositionX;
    public int onGridPositionY;

    public bool rotated = false;

    internal void Rotate()
    {
        rotated = !rotated;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.rotation = Quaternion.Euler(0, 0, rotated == true ? 90f : 0f);

    }

    internal void Set(ShipData shipData)
    {
        this.shipData = shipData;
        GetComponent<Image>().sprite = shipData.shipIcon;

        Vector2 size = new Vector2();
        size.x = WIDTH * ShipGrid.tileSizeWidth;
        size.y = HEIGHT * ShipGrid.tileSizeHeight;
        GetComponent<RectTransform>().sizeDelta = size;
    }
}

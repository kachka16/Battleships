using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGrid : MonoBehaviour
{
   
    public const float tileSizeWidth = 96;
    public const float tileSizeHeight = 96;

    FieldShip[,] fieldShipSlot;

    RectTransform rectTransform;

    [SerializeField] int gridSizeWidth = 10;
    [SerializeField] int gridSizeHeight = 10;
    [SerializeField] GameObject shipPrefab;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        fieldShipSlot = Init(gridSizeWidth, gridSizeHeight);
        if (gameObject.CompareTag("boxGrid"))
        {
            if (shipPrefab == null)
            {
                return;
            }
            FieldShip fieldShip = Instantiate(shipPrefab).GetComponent<FieldShip>();
            FieldShip overlapShip = null;
            PlaceShip(fieldShip, 0, 0, ref overlapShip);
        }
        
    }

    public FieldShip PickUpShip(int x, int y)
    {

        FieldShip toReturn = fieldShipSlot[x, y];

        if (toReturn == null) { return null; }

        CleanGridReference(toReturn);
        return toReturn;
    }

    private void CleanGridReference(FieldShip ship)
    {
        for (int ix = 0; ix < ship.WIDTH; ix++)
        {
            for (int iy = 0; iy < ship.HEIGHT; iy++)
            {
                fieldShipSlot[ship.onGridPositionX + ix, ship.onGridPositionY + iy] = null;
            }
        }
    }

    public FieldShip[,] Init(int width, int height)
    {
        FieldShip[,] tempFieldShipSlot = new FieldShip[width,height];
        Vector2 size = new Vector2(width * tileSizeWidth, height * tileSizeHeight);
        rectTransform.sizeDelta = size;
        return tempFieldShipSlot;
    }

    Vector2 positionOnTheGrid = new Vector2();
    Vector2Int tileGridPosition = new Vector2Int();
    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        positionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        positionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        tileGridPosition.x = (int)(positionOnTheGrid.x / tileSizeWidth);
        tileGridPosition.y = (int)(positionOnTheGrid.y / tileSizeHeight);

        return tileGridPosition;
    }

    public bool PlaceShip(FieldShip fieldShip, int posX, int posY, ref FieldShip overlapShip)
    {
        if (BoundryCheck(posX, posY, fieldShip.WIDTH, fieldShip.HEIGHT)==false) {
            return false;
        }
        if(OverlapCheck(posX,posY, fieldShip.WIDTH, fieldShip.HEIGHT,ref overlapShip)== false)
        {
            overlapShip = null;
            return false;
        }

        if(overlapShip != null)
        {
            CleanGridReference(overlapShip);
        }

        RectTransform rectTransform = fieldShip.GetComponent<RectTransform>();
        rectTransform.SetParent(this.rectTransform);
        for (int x = 0; x < fieldShip.WIDTH; x++)
        {
            for (int y = 0; y < fieldShip.HEIGHT; y++) { 
                fieldShipSlot[posX + x, posY+ y] = fieldShip;
             }
        }
        fieldShip.onGridPositionX = posX;
        fieldShip.onGridPositionY = posY;
        Vector2 position = new Vector2();
        position.x = posX * tileSizeWidth + tileSizeWidth * fieldShip.WIDTH/ 2;
        position.y = -(posY * tileSizeHeight + tileSizeHeight * fieldShip.HEIGHT / 2);

        rectTransform.localPosition = position;

        return true;
    }

    private bool OverlapCheck(int posX, int posY, int width, int height, ref FieldShip overlapShip)
    {
        for(int x = 0; x< width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if (fieldShipSlot[posX+ x, posY + y] != null)
                {
                    if (overlapShip == null)
                    {
                        overlapShip = fieldShipSlot[posX+x, posY + y];
                    }
                    else
                    {
                        if(overlapShip != fieldShipSlot[posX +x, posY+y]){
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    bool PositionCheck(int posX, int posY)
    {
        if(posX <0 || posY < 0){
            return false;
        }
        if(posX>= gridSizeWidth || posY>= gridSizeHeight){
            return false;
        }
        return true;
    }

    bool BoundryCheck(int posX, int posY, int width, int height)
    {
        if(PositionCheck(posX, posY)== false) { return false; }

        posX += width-1;
        posY += height-1;

        if(PositionCheck(posX,posY) == false) { return false; }

        return true;
    }
}

using NUnit.Framework;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldController : MonoBehaviour
{
    [HideInInspector]
    public ShipGrid selectedShipGrid;

    FieldShip selectedShip;
    FieldShip overlapShip;
    RectTransform rectTransform;

    [SerializeField] Transform canvasTransform;


    private void Update()
    {
        ShipIconDrag();

        if (selectedShipGrid == null) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseButtonPress();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateShip();
        }
    }

    private void RotateShip()
    {
        if (selectedShip == null) { return; }
     
            selectedShip.Rotate();
         
    }

    private void LeftMouseButtonPress()
    {
        Vector2 position = Input.mousePosition;

        if (selectedShip != null)
        {
            position.x -= (selectedShip.WIDTH - 1) * ShipGrid.tileSizeWidth / 2;
            position.y += (selectedShip.HEIGHT - 1) * ShipGrid.tileSizeHeight / 2;
        }

        Vector2Int tileGridPosition = selectedShipGrid.GetTileGridPosition(position);

        if (selectedShip == null)
        {
            PickUpShip(tileGridPosition);
        }
        else
        {
            PlaceShip(tileGridPosition);
        }
    }

    private void PlaceShip(Vector2Int tileGridPosition)
    {
        if(selectedShip == null || selectedShip == null)
        return;
        FieldShip overlapShip = null;
       bool complete = selectedShipGrid.PlaceShip(selectedShip, tileGridPosition.x, tileGridPosition.y, ref overlapShip);
        if (complete)
        {
 

            selectedShip = null;
            if(overlapShip != null)
            {
                selectedShip = overlapShip;
                overlapShip = null;
                rectTransform = selectedShip.GetComponent<RectTransform>();
            }
        }
    }

    private void PickUpShip(Vector2Int tileGridPosition)
    {
        selectedShip = selectedShipGrid.PickUpShip(tileGridPosition.x, tileGridPosition.y);
        if (selectedShip != null)
        {
            rectTransform = selectedShip.GetComponent<RectTransform>();
        }
    }

   private void ShipIconDrag()
    {
        if (selectedShip != null)
        {
            rectTransform.position = Input.mousePosition;
        }
    }
    
 
}

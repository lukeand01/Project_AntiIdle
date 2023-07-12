using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //control the mouse input here
    PlayerHandler handler;

    private void Awake()
    {
        handler = GetComponent<PlayerHandler>();
    }

    private void Update()
    {
        if (handler.block.HasBlock(BlockClass.BlockType.Complete)) return;

        PauseInput();

        if (handler.block.HasBlock(BlockClass.BlockType.Partial)) return;
        MouseInput();
    }

    //detect when we are hovering a house with building base script.

    void MouseInput()
    {

        BuildingBase building = GetBuilding();

        if (building == null)
        {
            UIHolder.instance.descriptor.StopDescribe();
            return;
        }
        building.ActUI(); 
        



    }


    public BuildingBase GetBuilding()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider == null) return null;


        //otherwise we check what this thing is doing.
        BuildingBase building = hit.collider.GetComponent<BuildingBase>();

        if (building == null) return null;

        if (building.isDestroyed) return null;

        return building;

        
    }

    void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) UIHolder.instance.pause.Control();
    }

    

    void CardInput()
    {
        //if you aree carrying a card input then 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PawnsController : MonoBehaviour, IPointerDownHandler
{
    Tile markedTile = new Tile();
    Color selectedColor = Color.red;
    Color defaultPawnColor;//
    Material pawnMaterial;
    Color defaultTileColor;//
    Material tileMaterial;
    PlayerInput inputActions;
    InputAction select;
    Vector3 canGoToTileRelativePosition = Vector3.forward;
    [SerializeField] Tile[] tiles = new Tile[64];
    PawnsMover pawnsMover = new PawnsMover();




    bool[,] pathPoints = new bool[8,8];

    bool isSelected = false;


    private void OnEnable()
    {
        inputActions = new PlayerInput();
        select = inputActions.Player.Select;
        select.Enable();
        //select.performed += Select;


    }
    private void OnDisable()
    {
        select.Disable();
    }
    void FillPawnPathPoints()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                pathPoints[i,j] = false;
            }
        }
        pathPoints[0+Mathf.RoundToInt(transform.position.x), 1 + Mathf.RoundToInt(transform.position.z)] = true;
        print(Mathf.RoundToInt(transform.position.x) + " " + Mathf.RoundToInt(transform.position.z));
    }
    //void FindCanGoTile()
    //{
    //    bool canGo = false;
    //    for (int i = 0; i < 8; i++)
    //    {
    //        for (int j = 0; j < 8; j++)
    //        {
    //            if (canGoToTileRelativePosition + transform.position == new Vector3(i, transform.position.y, j))
    //            {
    //                canGo = true;
    //            }
    //        }
    //    }
    //    if(canGo) gameObject.transform.Translate(canGoToTileRelativePosition);
    //}
    void Start()
    {
        FillPawnPathPoints();
        pawnMaterial = gameObject.GetComponent<MeshRenderer>().material;
        defaultPawnColor = pawnMaterial.color;
        

       // if(pawnsMover.MovePawnTo(PickCanGoToTiles().transform.position.x, PickCanGoToTiles().transform.position.z);
    }



    void PickCanGoToTiles()
    {
        
        if (isSelected)
        {
            foreach (var tile in tiles)
            {
                if (tile.transform.position - canGoToTileRelativePosition == new Vector3(transform.position.x, tile.transform.position.y, transform.position.z))
                {
                    tileMaterial = tile.GetComponent<MeshRenderer>().material;
                    defaultTileColor = tileMaterial.color;
                    tileMaterial.color = selectedColor;
                    markedTile = tile;
                }
                    
            }
            
        }
        else if(markedTile!=null)
        {
            tileMaterial.color = defaultTileColor;
        }
        
    }
    void PickPawn()
    {
        if (isSelected == true)
        {
            isSelected = false;
            pawnMaterial.color = defaultPawnColor;
        }
        else
        {
            isSelected = true;
            pawnMaterial.color = selectedColor;
        }
    }
    void SelectCanGoToTiles()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        PickPawn();
        PickCanGoToTiles();

    }

}

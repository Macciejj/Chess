using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PawnsController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Tile[] tiles = new Tile[64];
    Tile markedTile;
    
    Color selectedColor = Color.red;
    Color defaultPawnColor;
    Color defaultTileColor;

    Material pawnMaterial;
    Material tileMaterial;

    PlayerInput inputActions;
    InputAction select;

    Vector3 canGoToTileRelativePosition = Vector3.forward;
    
    public bool isSelected = false;


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

    void Start()
    {
        pawnMaterial = gameObject.GetComponent<MeshRenderer>().material;
        defaultPawnColor = pawnMaterial.color;
    }


   public void DeselectPawn()
    {
        isSelected = false;
        pawnMaterial.color = defaultPawnColor;
        tileMaterial.color = defaultTileColor;
        markedTile.isClickable = false;
    }
    void SelectPawn()
    {
        isSelected = true;
        pawnMaterial.color = selectedColor;

        foreach (var tile in tiles)
        {
            if (tile.transform.position - canGoToTileRelativePosition == new Vector3(transform.position.x, tile.transform.position.y, transform.position.z))
            {
                tileMaterial = tile.GetComponent<MeshRenderer>().material;
                defaultTileColor = tileMaterial.color;
                tileMaterial.color = selectedColor;
                markedTile = tile;
                markedTile.isClickable = true;
                markedTile.pawn = GetComponent<Pawn>();
            }

        }
    }
    void PickPawn()
    {
        if (isSelected == true)
        {
            DeselectPawn();
        }
        else
        {
            SelectPawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        PickPawn();
    }

}

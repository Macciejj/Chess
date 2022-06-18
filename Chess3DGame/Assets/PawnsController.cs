using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PawnsController : MonoBehaviour, IPointerDownHandler
{

    Color selectedColor = Color.red;
    Color defaultColor;
    Material material;
    PlayerInput inputActions;
    InputAction select;
    Vector3 canGoTilePosition = new Vector3(0, 0, 1);
   // [SerializeField] Tile[,] tiles = new Tile[8, 8];


    

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
    void FindCanGoTile()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (pathPoints[i, j]) {
                    gameObject.transform.Translate(canGoTilePosition);
                        }
            }
        }
    }
    void Start()
    {
        FillPawnPathPoints();
        material = gameObject.GetComponent<MeshRenderer>().material;
        defaultColor = material.color;
        FindCanGoTile();
    }

    

    // Update is called once per frame
    void Update()
    {
        print(isSelected);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSelected == true)
        {
            isSelected = false;
            material.color = defaultColor;
        }
        else
        {
            isSelected = true;
            material.color = selectedColor;
        }
        
    }
    //private void Select(InputAction.CallbackContext callbackContext)
    //{
    //    if (isSelected==true)
    //    {
    //        isSelected = false;
    //        material.color = defaultColor;
    //    }
        
    //}
}

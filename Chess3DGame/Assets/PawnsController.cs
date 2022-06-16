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
    void Start()
    {

        material = gameObject.GetComponent<MeshRenderer>().material;
        defaultColor = material.color;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerDownHandler
{
    public bool isClickable = false;
    public Pawn pawn;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(pawn!=null && isClickable)
        {
            pawn.GetComponent<PawnsMover>().MovePawnTo(transform.position.x, transform.position.z);
            pawn.GetComponent<PawnsController>().DeselectPawn();
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

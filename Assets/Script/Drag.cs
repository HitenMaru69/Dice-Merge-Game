using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler,IBeginDragHandler, IEndDragHandler
{
    public Image thisImage;
    public int number;
    public bool isMove;

    [HideInInspector]
    public Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        isMove = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isMove)
        {
            transform.position = eventData.position;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isMove)
        {
            thisImage.raycastTarget = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
        thisImage.raycastTarget = true;
        transform.position = startPosition;
        
    }

    
}

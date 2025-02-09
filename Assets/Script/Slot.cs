using UnityEngine;
using UnityEngine.EventSystems;
public enum SlotStatus
{
    Empty,
    Booked
}
public class Slot : MonoBehaviour, IDropHandler
{
    public int slotNumber;
    public SlotStatus status;
    public GameObject storeDragObject;
    public int matchNumber;

    private string slotTag = "Slot";
    private Slot slot;
    private void Start()
    {
        status = SlotStatus.Empty;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Drag drag = eventData.pointerDrag.GetComponent<Drag>();

            if (drag != null)
            {
                if (drag.isMove)
                {

                    if (gameObject.CompareTag(slotTag))
                    {
                        eventData.pointerDrag.transform.position = transform.position;
                        drag.startPosition = transform.position;
                        matchNumber = drag.number;
                        status = SlotStatus.Booked;
                        storeDragObject = eventData.pointerDrag.transform.gameObject;


                        GridManager.Instance.CheckAllSlotISBooked();

                        GridManager.Instance.OnCheckForMatch(slotNumber, matchNumber);

                        if (GridManager.Instance.isMatch)
                        {
                            GameManager.instance.ChangeObjectAfterMerge(drag, this);
                            GridManager.Instance.isMatch = false;
                        }

                        EventManager.Instance.InvokeSpwanNewObjectEvent();
                    }
                }
            
            }

        }
    }


}

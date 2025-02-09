using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public bool isMatch;

    [SerializeField] private List<GameObject> slotList;
    [SerializeField] private int gridWidth = 5;
    [SerializeField] private int gridHight = 4;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        isMatch = false;
    }

    #region  To check for similar objects in the grid

    public void OnCheckForMatch(int SlotNumber, int MatchNumber)
    {

        // Check Left Side

        if (SlotNumber % gridWidth > 1)
        {
            int number1 = SlotNumber - 1;
            int number2 = SlotNumber - 2;

            Slot slot = slotList[number1].GetComponent<Slot>();
            Slot slot2 = slotList[number2].GetComponent<Slot>();

            if (slot.status == SlotStatus.Booked && slot2.status == SlotStatus.Booked)
            {
                if (slot.matchNumber == MatchNumber && slot2.matchNumber == MatchNumber)
                {
                    isMatch=true;
                    DestroyObjectAndResetSlotValue(slot, slot2);
                    
                }
            }

        }

        // Check Right Side

        if (SlotNumber % gridWidth < gridWidth - 2)
        {
            int number1 = SlotNumber + 1;
            int number2 = SlotNumber + 2;

            Slot slot = slotList[number1].GetComponent<Slot>();
            Slot slot2 = slotList[number2].GetComponent<Slot>();

            if (slot.status == SlotStatus.Booked && slot2.status == SlotStatus.Booked)
            {
                if (slot.matchNumber == MatchNumber && slot2.matchNumber == MatchNumber)
                {
                    isMatch = true;
                    DestroyObjectAndResetSlotValue(slot, slot2);
                    
                }
            }
        }

        // Check Right And Left

        if (SlotNumber % gridWidth > 0 && SlotNumber % gridWidth < gridWidth - 1)
        {
            int number1 = SlotNumber + 1;
            int number2 = SlotNumber - 1;

            Slot slot = slotList[number1].GetComponent<Slot>();
            Slot slot2 = slotList[number2].GetComponent<Slot>();

            if (slot.status == SlotStatus.Booked && slot2.status == SlotStatus.Booked)
            {
                if (slot.matchNumber == MatchNumber && slot2.matchNumber == MatchNumber)
                {
                    isMatch = true;
                    DestroyObjectAndResetSlotValue(slot, slot2);                    
                }
            }

        }

        // Check For Bottom

        if (SlotNumber + gridWidth < gridWidth * gridHight - gridWidth)
        {
            int number1 = SlotNumber + gridWidth;
            int number2 = SlotNumber + gridWidth + gridWidth;

            Slot slot = slotList[number1].GetComponent<Slot>();
            Slot slot2 = slotList[number2].GetComponent<Slot>();

            if (slot.status == SlotStatus.Booked && slot2.status == SlotStatus.Booked)
            {
                if (slot.matchNumber == MatchNumber && slot2.matchNumber == MatchNumber)
                {
                    isMatch = true;
                    DestroyObjectAndResetSlotValue(slot, slot2);
                }

            }
        }

        // Check For Up

        if (SlotNumber - gridWidth > gridHight)
        {
            int number1 = SlotNumber - gridWidth;
            int number2 = (SlotNumber - gridWidth) - gridWidth;

            Slot slot = slotList[number1].GetComponent<Slot>();
            Slot slot2 = slotList[number2].GetComponent<Slot>();

            if (slot.status == SlotStatus.Booked && slot2.status == SlotStatus.Booked)
            {
                if (slot.matchNumber == MatchNumber && slot2.matchNumber == MatchNumber)
                {
                    isMatch = true;
                    DestroyObjectAndResetSlotValue(slot, slot2);
                    
                }

            }

        }

        // Check Up and Bottom

        if(SlotNumber + gridWidth < gridWidth * gridHight  && SlotNumber - gridWidth > 0)
        {
            int number1 = SlotNumber + gridWidth;
            int number2 = SlotNumber - gridWidth;

            Slot slot = slotList[number1].GetComponent<Slot>();
            Slot slot2 = slotList[number2].GetComponent<Slot>();

            if (slot.status == SlotStatus.Booked && slot2.status == SlotStatus.Booked)
            {
                if (slot.matchNumber == MatchNumber && slot2.matchNumber == MatchNumber)
                {
                    isMatch = true;
                    DestroyObjectAndResetSlotValue(slot, slot2);
                }

            }
        }


    }

    #endregion

    public void CheckAllSlotISBooked()
    {
        bool isALlBooked = false;

        foreach (var slots in slotList)
        { 
            Slot slot = slots.GetComponent<Slot>();
            if(slot.status != SlotStatus.Booked)
            {
                isALlBooked = false;
                break;
            }
            else { isALlBooked = true;}
        }

        if (isALlBooked) 
        { 
            EventManager.Instance.InvokeGameOverEvent();
        }

    }

    private void DestroyObjectAndResetSlotValue(Slot slot, Slot slot2)
    {
        EventManager.Instance.InvokeScoreUpdateEvent(slot.matchNumber, slot2.matchNumber);

        slot.status = SlotStatus.Empty;
        slot.matchNumber = 0;
        Destroy(slot.storeDragObject);

        slot2.status = SlotStatus.Empty;
        slot2.matchNumber = 0;
        Destroy(slot2.storeDragObject);
    }


}

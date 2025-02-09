using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Sprite> listOfObject;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeObjectAfterMerge(Drag drag,Slot slot)
    {
        if(drag.number < 6)
        {
            int number = drag.number += 1;
            drag.thisImage.sprite = listOfObject[drag.number - 1];
            drag.number = number;
            slot.matchNumber = number;
        }
        else
        {
            // Destroy all three gameObject if gameObject value is 6
            slot.matchNumber = 0;
            slot.status = SlotStatus.Empty;
            Destroy(drag.gameObject); 
           
        }

        
    }
}


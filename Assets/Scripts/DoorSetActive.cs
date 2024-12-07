using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isOpen = false;

    public void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            gameObject.SetActive(false); // Дверь открыта, объект отключён
        }
    }

    // Update is called once per frame
    public void CloseDoor()
    {
        if (isOpen)
        {
            isOpen = false;
            gameObject.SetActive(true); // Дверь закрыта, объект включён
        }
    }

    public void ToggleDoor()
    {
        //isOpen = !isOpen;
        if (isOpen)
        {
            //OpenDoor();
            CloseDoor();
        } 
        else
        {
            OpenDoor();
            //CloseDoor();
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class TestDoorOpen : MonoBehaviour
{
    [SerializeField] private DoorSetActive door;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            door.CloseDoor();
        }
    }
}

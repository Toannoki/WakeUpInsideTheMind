using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Camera_1;
    public GameObject Camera_2;
    public MoveRuller MoveRuller;
    
    public GameObject RightIcon;

    Interactable currentInteractable;

    public void Start()
    {
    }
    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            SwitchBack();   
        }
    }
    public void Switch()
    {
        HUDController.instance.SetCrosshairSize(false);
        Camera_1.SetActive(false);
        Camera_2.SetActive(true);
    }

    public void SwitchBack()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RightIcon.SetActive(false);
        if (MoveRuller != null)
            MoveRuller.enabled = false;
        Camera_1.SetActive(true);
        Camera_2.SetActive(false);
    }
}

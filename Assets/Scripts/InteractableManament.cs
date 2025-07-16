using UnityEngine;

public class InteractableManament : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Interactable interactable;

    public void Enable()
    {
        interactable.enabled = true;
    }
    public void Disable()
    {
        interactable.enabled = false;
    }
}

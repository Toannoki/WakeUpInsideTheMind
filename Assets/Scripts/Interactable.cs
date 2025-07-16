using System.Collections;
using System.Dynamic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteraction;
    public UnityEvent[] onInteraction2;

    private string[] DialogString;
    public TurnOnOff DialogPanel;

    public GameObject Camera;
    public SwitchCamera SwitchCamera;

    public GameObject ItemOnHand;
    private int CurrentEvent =0;

    void Start()
    {
        
    }
    public void Interact()
    {
        if (onInteraction2.Length >0)
            onInteraction2[CurrentEvent].Invoke();
        else
            onInteraction.Invoke();
    }
    
    public void SetDialog(int Index)
    {
        DialogString = Dialog.Instance.GetDialog(Index);
        DialogPanel.Dialog = DialogString;
    }

    public void SendCamera()
    {
        SwitchCamera.Camera_2 = Camera;
    }
    public void EnableInteractable()
    {
        this.enabled = true;
    }
    public void DisableInteractable()
    {
        this.enabled = false;
    }
    
    public void PlaceBear(GameObject BearInChair)
    {
        if (BearInChair.activeSelf)
        {
            BearInChair.SetActive(false);
            ItemOnHand.SetActive(true);
        }
        else
        {
            ItemOnHand.SetActive(false);
            BearInChair.SetActive(true);
        }      
    }
    public void SetEvent(int ev)
    {
        CurrentEvent = ev;
    }
    public void SetItemOnHand(GameObject ItOH)
    {
        ItemOnHand = ItOH;
    }    
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


public class Door : MonoBehaviour 
	{
	public bool open;
	public float smooth = 1.0f;
	public float DoorOpenAngle = -90.0f;
    public float DoorCloseAngle = 0.0f;
	public AudioSource asource;
	public AudioClip openDoor,closeDoor,blockDoor;

	public GameObject condition;
	public Interactable interactable;

	public bool isBlock;
	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (open)
		{
            var target = Quaternion.Euler (0, DoorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
	
		}
		else
		{
            var target1= Quaternion.Euler (0, DoorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
	
		}  
	}

	public void OpenDoor()
		{
			if (isBlock)
			{
                asource.clip = blockDoor;
                asource.Play();
                return;
            }
				
			if (CheckCondition())
            {
                open = !open;
                asource.clip = open ? openDoor : closeDoor;
                asource.Play();
            }
			else
			{	
				interactable.SetDialog(4);
                interactable.DialogPanel.TurnOn();
            }
	}
	public bool CheckCondition()
	{
		if (condition == null)
				return true;
		if (condition.activeSelf)
                return true;
		return false;

    }
	public void SetBlock(bool block)
		{
			isBlock = block;
		}

	public void CloseDoor()
		{
			if (open == true)
			{
                open = false;
                asource.clip = closeDoor;
                asource.Play();
            }
        }
}
}
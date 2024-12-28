using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Rotatemanager : MonoBehaviour
{
    [Header("Assign")]
    public float openr;//The angle when open.
    public float closer;//The angle when closed.
    public GameObject attached;//This is the object you want to rotate. For simple applications, Attach the object this script is attached to
    [Header("States")]
    public bool open = false;
    public bool interactable; //Can you do anything besides opening and closing it/does left click have any effect
    public bool closable; // can you close it or smth
    public bool Lock=false; // if true the door is locked

    // Start is called before the first frame update
    
    public void OnMouseOver()
    {
        //if you open door
        if (!closable)
        {
            goto interact;
        }
        if (Input.GetMouseButtonDown(0)&&!Lock)
        {
            if (open)
            {   
                attached.GetComponent<RotateOpen>().smoothrotation(closer);
            }
            else
            {
                attached.GetComponent<RotateOpen>().smoothrotation(openr);
            }
        open = !open;
        }
        interact:
        if (!interactable)
        {
            return;
        }
        //interactable code like running a function
    }
    public void ForceToggle()
    {
        if (open)
        {
            attached.GetComponent<RotateOpen>().smoothrotation(closer);
        }
        else
        {
            attached.GetComponent<RotateOpen>().smoothrotation(openr);
        }
        open = !open;
    }
}

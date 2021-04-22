using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorMotion : MonoBehaviour
{
    bool isOpen;
    Animator animator;
    void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="ManNeko")
        {
            isOpen = true;
            animator.SetTrigger("GlassOpen");
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(isOpen&& other.gameObject.tag == "ManNeko")
        {
            isOpen = false;
            animator.SetTrigger("GlassClose");
        }
    }
}

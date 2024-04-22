using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuAnimation : MonoBehaviour
{
    Animator animator;

    public void TriggerFadeOut()
    {
        animator.SetTrigger("disable");
    }

    public void DisableSelf()
    {
        this.gameObject.SetActive(false);
    }


    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
}

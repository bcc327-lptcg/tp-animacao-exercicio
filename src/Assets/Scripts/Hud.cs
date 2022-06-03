using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (anim.GetBool("Flexao"))
            {
                anim.SetBool("Flexao", false);
            }
            else
            {
                anim.SetBool("Flexao", true);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (anim.GetBool("Abdominal"))
            {
                anim.SetBool("Abdominal", false);
            }
            else
            {
                anim.SetBool("Abdominal", true);
            }
        }
    }
}

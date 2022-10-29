using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public Animator Player;
    public UIMenager UIMenager;
    public bool isRunning = false;
    private bool isStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRunning && !isStarted)
        {
            isRunning = true;
            isStarted = true;
            Player.SetBool("IsRunning", true);
            UIMenager.UIChanger(UIMenager.MainMenu, UIMenager.PlayUI);
        }

        if(isStarted && !isRunning)
        {
            UIMenager.UIChanger(UIMenager.PlayUI, UIMenager.FinishUI);
            Player.SetBool("IsRunning", false);
        }
    }

}

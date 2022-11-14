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
        // If mouse button pressed when player isn't running, start the player running animation and change the UI. 
        if (Input.GetMouseButtonDown(0) && !isRunning && !isStarted)
        {
            isRunning = true;
            isStarted = true;
            Player.SetBool("IsRunning", true);
            UIMenager.UIChanger(UIMenager.MainMenu, UIMenager.PlayUI);
        }
        // If game is started but player isn't running then the game is finished.
        if(isStarted && !isRunning)
        {
            UIMenager.UIChanger(UIMenager.PlayUI, UIMenager.FinishUI);
            Player.SetBool("IsRunning", false);
        }
    }

}

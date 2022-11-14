using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayUI;
    public GameObject FinishUI;

    // Activate or deactivate the given gameobjects.
    public void UIChanger(GameObject UIOff, GameObject UIOn)
    {
        UIOff.SetActive(false);
        UIOn.SetActive(true);
    }

    // Load the next level.
    public void NextLevelBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

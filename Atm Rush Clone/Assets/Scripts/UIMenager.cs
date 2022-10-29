using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayUI;
    public GameObject FinishUI;

    public void UIChanger(GameObject UIOff, GameObject UIOn)
    {
        UIOff.SetActive(false);
        UIOn.SetActive(true);
    }

    public void NextLevelBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

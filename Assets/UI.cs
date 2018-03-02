using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject AllProfile;
    public GameObject SVPM;
    public GameObject ProfileName;
    public GameObject HighScores;


    public void SetMainScreen()
    {
        MainMenu.SetActive(true);
        AllProfile.SetActive(false);
        SVPM.SetActive(false);
        ProfileName.SetActive(false);
        HighScores.SetActive(false);

    }
    public void SetAllProfile()
    {
        MainMenu.SetActive(false);
        AllProfile.SetActive(true);
        SVPM.SetActive(false);
        ProfileName.SetActive(false);
        HighScores.SetActive(false);

    }
    public void SetSVPM()
    {
        MainMenu.SetActive(false);
        AllProfile.SetActive(false);
        SVPM.SetActive(true);
        ProfileName.SetActive(false);
        HighScores.SetActive(false);

    }
    public void Setprofilename()
    {
        MainMenu.SetActive(false);
        AllProfile.SetActive(false);
        SVPM.SetActive(false);
        ProfileName.SetActive(true);
        HighScores.SetActive(false);

    }
    public void SetHighscores()
    {
        MainMenu.SetActive(false);
        AllProfile.SetActive(false);
        SVPM.SetActive(false);
        ProfileName.SetActive(false);
        HighScores.SetActive(true);

    }
}

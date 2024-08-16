using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSetup : MonoBehaviour
{
   public void Choi()
    {
        SceneManager.LoadScene(1);
    }
    public void Thoat()
    {
        Application.Quit();
    }
    public void QuayLai()
    {
        SceneManager.LoadScene(0);
    }
}

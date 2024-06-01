using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class TitleMenuManager : MonoBehaviour
{
    public void _GameStartBtn()
    {
        SceneManager.LoadScene("Character Select Scene");
    }
    public void _ExitBtn()
    {
        Application.Quit();
    }
}

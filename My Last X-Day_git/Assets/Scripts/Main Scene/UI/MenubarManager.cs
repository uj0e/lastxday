using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//UI > Menubar 오브젝트
public class MenubarManager : MonoBehaviour
{
    public void User_MainMenu()
    {
        SceneManager.LoadScene("Title Scene");
    }
}

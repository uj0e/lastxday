using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeHouseSceneButtonManager : MonoBehaviour
{
    public void _ExploreBtn()
    {
        SceneManager.LoadScene("Main Play Scene");
    }
}

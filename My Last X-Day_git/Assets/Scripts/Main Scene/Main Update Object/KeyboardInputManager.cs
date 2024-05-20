using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Update ������Ʈ
public class KeyboardInputManager : MonoBehaviour
{
    [SerializeField] GameObject m_UI;
    public void _KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var obj = m_UI.transform.Find("Menubar").gameObject;
            var isActive = obj.activeSelf;
            obj.SetActive(isActive ? false : true);
        }
    }
}

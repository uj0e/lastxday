using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    //[SerializeField] GameObject m_textBackground;
    [SerializeField] TextMeshProUGUI m_text;
    [SerializeField] int m_objID;

    public TextMeshProUGUI m_Text { get {  return m_text; } }
    public int m_ObjID { get { return m_objID; } }
}

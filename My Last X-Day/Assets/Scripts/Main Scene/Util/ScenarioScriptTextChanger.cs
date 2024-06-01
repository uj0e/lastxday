using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioScriptTextChanger : MonoBehaviour
{
    Dictionary<int, string> m_scriptData;
    void Start()
    {
        m_scriptData = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData()
    {
        m_scriptData.Add(0, "������");
        m_scriptData.Add(1, "�������Դϴ�.");
        m_scriptData.Add(2, "����������~.");
        m_scriptData.Add(3, "�����ϰ�?");
        m_scriptData.Add(4, "�Ʒ����̴�.");
    }

    public string GetTalk(int id)
    {
        return m_scriptData[id];
    }
}

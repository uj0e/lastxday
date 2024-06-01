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
        m_scriptData.Add(0, "이히히");
        m_scriptData.Add(1, "오른쪽입니다.");
        m_scriptData.Add(2, "왼쪽이지롱~.");
        m_scriptData.Add(3, "위쪽일걸?");
        m_scriptData.Add(4, "아래쪽이다.");
    }

    public string GetTalk(int id)
    {
        return m_scriptData[id];
    }
}

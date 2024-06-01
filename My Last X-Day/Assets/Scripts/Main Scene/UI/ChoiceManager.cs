using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] GameObject m_CR;
    [SerializeField] ScenarioScriptTextChanger m_scenarioScriptTextChanger;

    //inspector 창에서 무슨 오브젝트가 선택되었나 확인하려고 선언
    [SerializeField] GameObject m_scanObject;

    private ObjData m_isRaycastSensorChange;
    private ObjData m_IsRaycastSensorChange
    {
        get { return m_isRaycastSensorChange; }
        set
        {
            //OnIsFromCRchanged(): m_isRaycastSensorChange 값 변경 감지
            //감지 후 값 변경
            if (m_isRaycastSensorChange != value)
            {
                OnIsFromCRchanged();
                m_isRaycastSensorChange = value;
            }
        }
    }
    public void Action()
    {
        UpdateSelectionRangeObject();
        m_isRaycastSensorChange?.m_Text.gameObject.SetActive(true);

            //    m_objData = m_scanObject.GetComponent<ObjData>();
            //    m_objData.m_Text.text = m_scenarioScriptTextChanger.GetTalk(m_objData.m_ObjID);
    }

    private void UpdateSelectionRangeObject()
    {

        Vector3 rayDirection = m_CR.transform.forward;
        RaycastHit hit;
        bool isTrue = Physics.Raycast(m_CR.transform.position, rayDirection, out hit, Mathf.Infinity, LayerMask.GetMask("Selection Range"));

        if (isTrue && hit.collider.tag == "Selection Range")
        {
            m_scanObject = hit.collider.gameObject;
            m_IsRaycastSensorChange = m_scanObject.gameObject.GetComponent<ObjData>();
        }
        else
        {
            //m_scanObject, m_IsRaycastSensorChange 초기화
            m_scanObject = null;
            m_IsRaycastSensorChange = null;
        }
    }

    //m_isRaycastSensorChange 값 변경 감지
    private void OnIsFromCRchanged()
    {
        //Bug Report: CR을 빠른 속도로 움직일 시, RaycastFromCRSensor 스크립트의 SelectionTextActivator()에 SetActive(false)가
        //작동하지 않는 버그 발생. 아래 코드로 버그해결.

        //값 변경 감지되면 오브젝트 DeActivate
        //최초 1회에 m_isRaycastSensorChange은 null이므로 ?(널 조건 연산자)로 처리
        m_isRaycastSensorChange?.m_Text.gameObject.SetActive(false);
    }
}
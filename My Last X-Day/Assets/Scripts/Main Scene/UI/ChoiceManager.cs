using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] GameObject m_CR;
    [SerializeField] ScenarioScriptTextChanger m_scenarioScriptTextChanger;

    //inspector â���� ���� ������Ʈ�� ���õǾ��� Ȯ���Ϸ��� ����
    [SerializeField] GameObject m_scanObject;

    private ObjData m_isRaycastSensorChange;
    private ObjData m_IsRaycastSensorChange
    {
        get { return m_isRaycastSensorChange; }
        set
        {
            //OnIsFromCRchanged(): m_isRaycastSensorChange �� ���� ����
            //���� �� �� ����
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
            //m_scanObject, m_IsRaycastSensorChange �ʱ�ȭ
            m_scanObject = null;
            m_IsRaycastSensorChange = null;
        }
    }

    //m_isRaycastSensorChange �� ���� ����
    private void OnIsFromCRchanged()
    {
        //Bug Report: CR�� ���� �ӵ��� ������ ��, RaycastFromCRSensor ��ũ��Ʈ�� SelectionTextActivator()�� SetActive(false)��
        //�۵����� �ʴ� ���� �߻�. �Ʒ� �ڵ�� �����ذ�.

        //�� ���� �����Ǹ� ������Ʈ DeActivate
        //���� 1ȸ�� m_isRaycastSensorChange�� null�̹Ƿ� ?(�� ���� ������)�� ó��
        m_isRaycastSensorChange?.m_Text.gameObject.SetActive(false);
    }
}
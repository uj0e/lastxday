using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] GameObject m_ChoiceRectangle;
    [SerializeField] GameObject m_scanObject;
    [SerializeField] ScenarioScriptTextChanger m_scenarioScriptTextChanger;

    [SerializeField] ObjData objData;
    public void Action()
    {
        bool raycastFromCRToSelectionRange;
        UpdateSelectionRangeObject(out raycastFromCRToSelectionRange);

        if (m_scanObject != null)
        {
            objData = m_scanObject.GetComponent<ObjData>();
            objData.m_Text.text = m_scenarioScriptTextChanger.GetTalk(objData.m_ObjID);
        }
        if (objData != null)
        {
            objData.m_Text.gameObject.SetActive(raycastFromCRToSelectionRange);
        }

    }

    private void UpdateSelectionRangeObject(out bool raycastFromCRToSelectionRange)
    {
        raycastFromCRToSelectionRange = false;

        Vector3 rayDirection = m_ChoiceRectangle.transform.forward;
        RaycastHit hit;
        bool isTrue = Physics.Raycast(m_ChoiceRectangle.transform.position, rayDirection, out hit, Mathf.Infinity, LayerMask.GetMask("Selection Range"));

        if (isTrue && hit.collider.tag == "Selection Range")
        {
            m_scanObject = hit.collider.gameObject;
            raycastFromCRToSelectionRange = true;
        }
        else
        {
            //m_scanObject √ ±‚»≠
            m_scanObject = null;
        }
    }
}
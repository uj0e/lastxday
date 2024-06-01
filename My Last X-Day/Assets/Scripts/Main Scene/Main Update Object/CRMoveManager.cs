using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//Main Update ������Ʈ
public class CRMoveManager : MonoBehaviour
{
    [SerializeField] GameObject m_CR;
    [SerializeField] GameObject m_CRClickableRange;

    float m_maxDist = 4f;
    float m_sqrMaxDist;
    

    // ���콺 ��Ŭ�� Ű�ٿ� ��, CR�� ���ð��� �����̸� m_isDragging = true
    public void CRGetMouseButtonDown(RaycastHit hit, out bool m_isDragging)
    {
        m_isDragging = false;

        if (hit.collider.gameObject.transform == m_CRClickableRange.transform)
        {
            m_isDragging = true;
        }
    }
    //���콺 ��Ŭ�� Ű��
    public void CRGetMouseButtonUp(out bool m_isDragging)
    {
        m_isDragging = false;
        m_CR.transform.localPosition = Vector3.zero;
    }
    //CR Ŭ�� ��, �巡�� �� ����
    public void CRDraggable(Camera m_mainCamera)
    {
        var mainCameraPoint = m_mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var dir = mainCameraPoint - m_CR.transform.position;

        if (dir.sqrMagnitude <= m_sqrMaxDist)
        {
            m_CR.transform.position = m_CRClickableRange.transform.position + dir;
        }
        else
        {
            m_CR.transform.position = m_CRClickableRange.transform.position + dir.normalized * m_maxDist;
        }
    }
    private void Awake()
    {
        m_sqrMaxDist = m_maxDist * m_maxDist;
    }
}

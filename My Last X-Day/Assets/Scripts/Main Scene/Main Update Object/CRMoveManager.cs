using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//Main Update 오브젝트
public class CRMoveManager : MonoBehaviour
{
    [SerializeField] GameObject m_CR;
    [SerializeField] GameObject m_CRClickableRange;

    float m_maxDist = 4f;
    float m_sqrMaxDist;
    

    // 마우스 좌클릭 키다운 시, CR의 선택가능 영역이면 m_isDragging = true
    public void CRGetMouseButtonDown(RaycastHit hit, out bool m_isDragging)
    {
        m_isDragging = false;

        if (hit.collider.gameObject.transform == m_CRClickableRange.transform)
        {
            m_isDragging = true;
        }
    }
    //마우스 좌클릭 키업
    public void CRGetMouseButtonUp(out bool m_isDragging)
    {
        m_isDragging = false;
        m_CR.transform.localPosition = Vector3.zero;
    }
    //CR 클릭 후, 드래그 시 실행
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

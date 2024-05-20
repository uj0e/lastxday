using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Main Update 오브젝트
public class Main : MonoBehaviour
{
    [SerializeField] Camera m_mainCamera;

    [SerializeField] ChoiceManager m_choiceManager;
    [SerializeField] CRMoveManager m_CRMoveManager;
    [SerializeField] KeyboardInputManager m_keyboardIM;
    

    private bool m_isDragging = false;

    void Update()
    {
        //키보드 입력 감지
        m_keyboardIM._KeyboardInput();
        m_choiceManager.Action();

        //UI 위에서 마우스 이벤트 제한
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //마우스 좌클릭 키다운
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    m_CRMoveManager.CRGetMouseButtonDown(hit, out m_isDragging);
                }
            }
            //마우스 좌클릭 키업
            else if (Input.GetMouseButtonUp(0))
            {
                m_CRMoveManager.CRGetMouseButtonUp(out m_isDragging);
            }
            if (m_isDragging)
            {
                m_CRMoveManager.CRDraggable(m_mainCamera);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Main Update ������Ʈ
public class Main : MonoBehaviour
{
    [SerializeField] Camera m_mainCamera;

    [SerializeField] ChoiceManager m_choiceManager;
    [SerializeField] CRMoveManager m_CRMoveManager;
    [SerializeField] KeyboardInputManager m_keyboardIM;
    

    private bool m_isDragging = false;

    void Update()
    {
        //Ű���� �Է� ����
        m_keyboardIM._KeyboardInput();
        m_choiceManager.Action();

        //UI ������ ���콺 �̺�Ʈ ����
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //���콺 ��Ŭ�� Ű�ٿ�
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    m_CRMoveManager.CRGetMouseButtonDown(hit, out m_isDragging);
                }
            }
            //���콺 ��Ŭ�� Ű��
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

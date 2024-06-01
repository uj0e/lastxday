using UnityEngine;
using UnityEngine.Events;

public class ObjActivateSensor : MonoBehaviour
{
    // UnityEvent ����
    [SerializeField] UnityEvent OnActivated;
    [SerializeField] UnityEvent OnDeactivated;

    // ������Ʈ�� Ȱ��ȭ�� �� ȣ��
    private void OnEnable()
    {
        OnActivated.Invoke(); // OnActivated �̺�Ʈ Ʈ����
    }

    // ������Ʈ�� ��Ȱ��ȭ�� �� ȣ��
    private void OnDisable()
    {
        OnDeactivated.Invoke(); // OnDeactivated �̺�Ʈ Ʈ����
    }
}
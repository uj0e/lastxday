using UnityEngine;
using UnityEngine.Events;

public class ObjActivateSensor : MonoBehaviour
{
    // UnityEvent 정의
    [SerializeField] UnityEvent OnActivated;
    [SerializeField] UnityEvent OnDeactivated;

    // 오브젝트가 활성화될 때 호출
    private void OnEnable()
    {
        OnActivated.Invoke(); // OnActivated 이벤트 트리거
    }

    // 오브젝트가 비활성화될 때 호출
    private void OnDisable()
    {
        OnDeactivated.Invoke(); // OnDeactivated 이벤트 트리거
    }
}
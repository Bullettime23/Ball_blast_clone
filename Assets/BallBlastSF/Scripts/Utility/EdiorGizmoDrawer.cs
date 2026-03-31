using UnityEngine;

public class EdiorGizmoDrawer : MonoBehaviour
{
    [SerializeField] private float width;

    private void Start()
    {
        Debug.Log(transform.localScale.z);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3(width * 0.5f, 0, 0), transform.position + new Vector3(width * 0.5f, 0, 0));
    }
#endif
}

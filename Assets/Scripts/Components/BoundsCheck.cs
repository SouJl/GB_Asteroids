using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    public float camWidth;
    public float camHeight;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        if (!keepOnScreen) return;

        var pos = transform.position;
       
        pos.x = Mathf.Clamp(pos.x, (-camWidth + radius), (camWidth - radius));     
        pos.y = Mathf.Clamp(pos.y, (-camHeight + radius), (camHeight - radius));

        transform.position = pos;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        var boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}

using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField]private float _radius = 1f;
    [SerializeField]private bool _keepOnScreen = true;

    private float _camWidth;
    private float _camHeight;

    public float Radius { get => _radius; set => _radius = value; }
    public float CamWidth { get => _camWidth; private set => _camWidth = value; }
    public float CamHeight { get => _camHeight; private set => _camHeight = value; }

    void Awake()
    {
        CamHeight = Camera.main.orthographicSize;
        CamWidth = CamHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        if (!_keepOnScreen) return;

        var pos = transform.position;
       
        pos.x = Mathf.Clamp(pos.x, (-CamWidth + Radius), (CamWidth - Radius));     
        pos.y = Mathf.Clamp(pos.y, (-CamHeight + Radius), (CamHeight - Radius));

        transform.position = pos;
    }

    public bool IsOutOfBounds() 
    {
        if (_keepOnScreen) return false;

        var pos = transform.position;

        if (pos.x > CamWidth || pos.x < -CamWidth) return true;
        if (pos.y > CamHeight || pos.y < -CamHeight) return true;

        return false;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        var boundSize = new Vector3(CamWidth * 2, CamHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}

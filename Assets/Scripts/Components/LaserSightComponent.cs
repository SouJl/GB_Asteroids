using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserSightComponent : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 100f;

    private LineRenderer _laser;

    private void Awake()
    {
        _laser = GetComponent<LineRenderer>();
    }


    void Update()
    {
        float laserDistance = _maxDistance;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if (hit.collider.tag == "Enemy") 
            {
                laserDistance = hit.distance;
            }
        }

        _laser.SetPosition(1, new Vector3(0, 0, laserDistance));
    }
}

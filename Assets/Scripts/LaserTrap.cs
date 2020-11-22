using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField]
    private float defDistanceRay = 100;
    public int damageAmount = 5;
    private bool hitPlayer;
    public LineRenderer m_lineRenderer;
    public Transform laserFirePoint;
    Transform m_transform;
    public Vector3 m_from = new Vector3(0, 0, 45.0f);
    public Vector3 m_to = new Vector3(0, 0, -45.0f);
    public float rotationSpeed = 0.4f;
     private void Awake()
    {
        m_transform = GetComponent<Transform>();
        hitPlayer = true;
    }

    private void Update()
    {
        // Rotates the laser 360
        // m_transform.Rotate(Vector3.forward*10*Time.deltaTime);
        Quaternion from = Quaternion.Euler(m_from);
        Quaternion to = Quaternion.Euler(m_to);
        float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * rotationSpeed));
        m_transform.localRotation = Quaternion.Lerp(from, to, lerp);
        ShootLaser();
    }



    void ShootLaser()
    {
        if (Physics2D.Raycast(m_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.right);
            if (_hit.collider.tag == "Player")
            {
                Debug.Log("Laser hit player");
                if (hitPlayer)
                {
                    hitPlayer = false;
                    PlayerHealth playerHeatlh = _hit.collider.gameObject.GetComponent<PlayerHealth>();
                    playerHeatlh.takeDamage(damageAmount);
                }
            }
            else { hitPlayer = true; }
            Draw2DRay(laserFirePoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }

    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}

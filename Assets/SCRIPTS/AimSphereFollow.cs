using UnityEngine;
public class AimSphereController : MonoBehaviour
{
    private Transform cam; public float range = 200f; public GameObject pistolSphere; public GameObject m16Sphere; void Update()
    {
        Ray ray = new(cam.position, cam.forward); Vector3 point; if (Physics.Raycast(ray, out RaycastHit hit, range)) { point = hit.point; } else { point = ray.GetPoint(range); }
        pistolSphere.transform.position = point;
        m16Sphere.transform.position = point;
    }
}
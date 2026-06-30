using Unity.VisualScripting;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    public static InteractionManager Instance { get; set; }

    public Weapon hoveredWeapon = null;
    public Throwable hoveredThrowable = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject objectHitByRaycast = hit.transform.gameObject;


            Weapon weapon = objectHitByRaycast.GetComponentInParent<Weapon>();

            Weapon Weapon = objectHitByRaycast.GetComponent<Weapon>();

            // REMOVE outline from previous hovered weapon
            if (hoveredWeapon != null && hoveredWeapon != weapon)
            {
                Outline oldOutline = hoveredWeapon.GetComponent<Outline>();
                if (oldOutline != null)
                    oldOutline.enabled = false;
            }

            // CHECK new weapon
            if (weapon != null && weapon.isActiveWeapon == false)
            {



                hoveredWeapon = weapon;

                Outline outline = hoveredWeapon.GetComponent<Outline>();
                if (outline != null)
                    outline.enabled = true;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    WeaponManager.Instance.PickupWeapon(objectHitByRaycast.gameObject);

                    // IMPORTANT: disable outline after pickup
                    if (outline != null)
                        outline.enabled = false;
                }
            }
            else
            {
                // If not looking at valid weapon → remove outline
                if (hoveredWeapon != null)
                {
                    Outline outline = hoveredWeapon.GetComponent<Outline>();
                    if (outline != null)
                        outline.enabled = false;

                    hoveredWeapon = null;
                }
            }

            if (objectHitByRaycast.GetComponent<Throwable>())
            {
                hoveredThrowable = objectHitByRaycast.gameObject.GetComponent<Throwable>();
                hoveredThrowable.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    WeaponManager.Instance.PickupThrowable(hoveredThrowable);
                    Destroy(objectHitByRaycast);
                }

            }
            else
            {
                if (hoveredThrowable)
                {
                    hoveredThrowable.GetComponent<Outline>().enabled = false;
                }
            }
        }
    }
}

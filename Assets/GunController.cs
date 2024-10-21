using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Animator gunAnim;
    [SerializeField] private Transform gun;
   
    void Update()
    {
        UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector3 direction = mousePos - gunAnim.bodyPosition;

        gun.rotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0,0,Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg));

        if(Input.GetKeyDown(KeyCode.Mouse0))
          Shoot();
    }

    public void Shoot() 
    {
        gunAnim.SetTrigger("Shoot");
    }   
}


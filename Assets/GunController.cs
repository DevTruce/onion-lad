using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Animator gunAnim;
    [SerializeField] private Transform gun;
    [SerializeField] private float gunDistance = 1.5f;

    private bool gunFacingRight = true;

    void Update()
    {
        UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector3 direction = mousePos - transform.position;

        gun.rotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0,0,Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg));

        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        gun.position = transform.position + UnityEngine.Quaternion.Euler(0,0,angle) * new UnityEngine.Vector3(gunDistance,0,0);

        if(Input.GetKeyDown(KeyCode.Mouse0))
          Shoot();

        GunFlipController(mousePos);
        
        
    }

    public void Shoot() 
    {
        gunAnim.SetTrigger("Shoot");
    }   

    public void GunFlip() 
    {
        gunFacingRight =!gunFacingRight; // works as a switcher
        gun.localScale = new UnityEngine.Vector3(gun.localScale.x, gun.localScale.y * -1, gun.localScale.z);
    }

    public void GunFlipController(UnityEngine.Vector3 mousePos) 
    {
        if(mousePos.x < gun.position.x && gunFacingRight) 
          GunFlip();
        else if (mousePos.x > gun.position.x && !gunFacingRight) 
          GunFlip();
    }

}


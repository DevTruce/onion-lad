using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Animator gunAnim;
    [SerializeField] private Transform gun;
    [SerializeField] private float gunDistance = 1.5f;
    [SerializeField] private int maxBullets = 15;

    private int currentBullets;

    private void Start() 
    {
      ReloadGun();
    }

    private bool gunFacingRight = true;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    void Update()
    {
      if (UI.instance.canPlayerShoot == false) return;

      UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      UnityEngine.Vector3 direction = mousePos - transform.position;

      gun.rotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0,0,Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg));

      float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
      gun.position = transform.position + UnityEngine.Quaternion.Euler(0,0,angle) * new UnityEngine.Vector3(gunDistance,0,0);

      if(Input.GetKeyDown(KeyCode.Mouse0) && HaveBullets())
        Shoot(direction);

      if(Input.GetKeyDown(KeyCode.R))
      {
        ReloadGun();
      }

      GunFlipController(mousePos);
        
        
    }
 
    public void Shoot(UnityEngine.Vector3 direction) 
    {
      gunAnim.SetTrigger("Shoot");
      UI.instance.UpdateAmmoText(currentBullets, maxBullets);


      GameObject newBullet = Instantiate(bulletPrefab, gun.position, UnityEngine.Quaternion.identity);

      newBullet.GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * bulletSpeed;

      Destroy(newBullet, 7);
    }   

    private void ReloadGun() 
    {
      currentBullets = maxBullets;
      UI.instance.UpdateAmmoText(currentBullets, maxBullets);

    }

    public bool HaveBullets() 
    {
      if(currentBullets <= 0) 
      {
        return false;
      }

      currentBullets--;
      return true;
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


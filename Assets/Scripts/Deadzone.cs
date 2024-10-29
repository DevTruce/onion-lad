using UnityEngine;

public class Deadzone : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Target" || collision.tag == "Player")
    {
        Time.timeScale = 0;
        Debug.Log("You Lost.");
    }
  }
}
 
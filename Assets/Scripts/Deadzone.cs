using UnityEngine;

public class Deadzone : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Target" || collision.tag == "Player")
    {
        UI.instance.OpenEndScreen(); // this will end the game
    }
  }
}
 
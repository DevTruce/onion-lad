using UnityEngine;
using UnityEngine.U2D.IK;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] targetSprite;
    [SerializeField] private BoxCollider2D BC;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float cooldown;
    public float timer;

    private int sushiCreated;
    private int sushiMilestone = 10;

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0) 
        {

            timer = cooldown;
            sushiCreated++;

            if(sushiCreated > sushiMilestone && cooldown > .5f) 
            {
                sushiMilestone += 10;
                cooldown -= .3f;
            }

            GameObject newTarget = Instantiate(targetPrefab);

            float randomX = Random.Range(BC.bounds.min.x, BC.bounds.max.x);

            newTarget.transform.position = new Vector2(randomX, transform.position.y);
            newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[Random.Range(0, targetSprite.Length)];
        }
    }
}

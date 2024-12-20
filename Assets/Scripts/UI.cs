using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;

   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private TextMeshProUGUI timerText;
   [SerializeField] private TextMeshProUGUI ammoText;
   private int scoreValue;
   public bool canPlayerShoot;

   [SerializeField] private GameObject TryAgainButton;

   private void Awake() 
   {
    instance = this;
   }

    void Start()
    {
        canPlayerShoot = true;
    }


    void Update()
    {
        if(Time.time >= 1)
        {
            timerText.text = Time.time.ToString("#,#");
        }
        
    }

    public void AddScore() 
    {
        scoreValue++;
        scoreText.text = scoreValue.ToString("#,#");
    }

    public void UpdateAmmoText(int currentBullets, int maxBullets) 
    {
        ammoText.text = currentBullets + "/" + maxBullets;
    }

    public void OpenEndScreen() 
    {
      Time.timeScale = 0;
      canPlayerShoot = false;
      TryAgainButton.SetActive(true);
    }

    public void RestartGame() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

using UnityEngine;

/*
 * On screen HUD to display current health.
 */
public class PlayerHud : MonoBehaviour
{
  private PlayerController playerController;
  private Texture2D halfHeart;
  private Texture2D heart;
    public int height = 250;
    public int halfWidth = 250;
    private int width;
  /*
   * Load and store the heart images and cache the PlayerController
   * component for later.
   */
  private void Start()
  {
    playerController = GetComponent<PlayerController>();
    heart = Resources.Load<Texture2D>("胡萝卜两个");
    halfHeart = Resources.Load<Texture2D>("胡萝卜单个");
        width = halfWidth * 2;
    }

  /*
   * Using the current health from the PlayerController, display the
   * correct number of hearts and half hearts.
   */
  private void OnGUI()
  {
    if (playerController.GetHealth() == 6)
    {
      GUI.DrawTexture(new Rect(10, 10, width, height), heart);
      GUI.DrawTexture(new Rect(10+width, 10, width, height), heart);
      GUI.DrawTexture(new Rect(10+2*width, 10, width, height), heart);
    }
    else if(playerController.GetHealth() == 5)
    {
      GUI.DrawTexture(new Rect(10, 10, width, height), heart);
      GUI.DrawTexture(new Rect(10+width, 10, width, height), heart);
      GUI.DrawTexture(new Rect(10+2*width, 10, halfWidth, height), halfHeart);
    }
    else if(playerController.GetHealth() == 4)
    {
      GUI.DrawTexture(new Rect(10, 10, width, height), heart);
      GUI.DrawTexture(new Rect(10+width, 10, width, height), heart);
    }
    else if(playerController.GetHealth() == 3)
    {
      GUI.DrawTexture(new Rect(10, 10, width, height), heart);
      GUI.DrawTexture(new Rect(10+width, 10, halfWidth, height), halfHeart);
    }
    else if(playerController.GetHealth() == 2)
    {
      GUI.DrawTexture(new Rect(10, 10, width, height), heart);
    }
    else if(playerController.GetHealth() == 1)
    {
      GUI.DrawTexture(new Rect(10, 10, halfWidth, height), halfHeart);
    }
  }
}

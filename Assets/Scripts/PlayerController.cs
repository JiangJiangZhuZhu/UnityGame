using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Behaviour to handle keyboard input and also store the player's
 * current health.
 */
public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rigidbody2d;
  private int health;
  private bool canJump;
    private int jumpCount;
    private int healthMax = 3;
    private GameObject scoreText;
    /*
     * Apply initial health and also store the Rigidbody2D reference for
     * future because GetComponent<T> is relatively expensive.
     */
    private void Start()
    {
        Global.score = 0;
        health = healthMax;
        rigidbody2d = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        Global.score = 0;
        scoreText = GameObject.Find("Score");
    }

    /*
     * Remove one health unit from player and if health becomes 0, change
     * scene to the end game scene.
     */
    public void Damage()
  {
    health -= 1;
    AudioManager.Instance.Play("Boss死了");
    if(health < 1)
    {
         //AudioManager.Instance.Play("Boss死了");
            Global.dateTime = DateTime.Now;
            SceneManager.LoadScene("EndGame");
    }
  }


  public void AddHealth()
  {
      if (health < healthMax)
      {
          health += 1;
      }

  }
  /*
   * Accessor for health variable, used by he HUD to display health.
   */
  public int GetHealth()
  {
    return health;
  }

  /*
   * Poll keyboard for when the up arrow is pressed. If the player can jump
   * (is on the ground) then add force to the cached Rigidbody2D component.
   * Finally unset the canJump flag so the player has to wait to land before
   * another jump can be triggered.
   */
    private void Update()
    {
        Global.score += Time.deltaTime*10;
        scoreText.GetComponent<Text>().text = "得分："+(int)Global.score;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump == true)
            {
                rigidbody2d.AddForce(new Vector2(0, 500));
                AudioManager.Instance.Play("跳");
                jumpCount++;
                if (jumpCount >= 2)
                {
                    canJump = false;
                    jumpCount = 0;
                }
            }
        }
    }
    /*
     * If the player has collided with the ground, set the canJump flag so that
     * the player can trigger another jump.
     */
    private void OnCollisionEnter2D(Collision2D other)
  {
    canJump = true;
  }
}

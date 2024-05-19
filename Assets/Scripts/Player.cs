using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider healthSlider;
    public Text tPoint;
    public GameObject objGameOver;
    public GameObject youWin;
    public Animator animator;

    private int health = 100;
    private int point = 0;
    private int timeS = 1;
    private bool isHit = false;

    void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        Time.timeScale = timeS;
    }

    private void LateUpdate()
    {
        if (!isHit) return;
        isHit = false;
        animator.SetBool("isHit", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            minusHealth(10);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            if(point == 10)
            {
                Debug.Log("You Win");
                youWin.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void addHealth(int index)
    {
        if (index < 0) return;
        health += index;
        if(health > 100) health = 100;
        healthSlider.value = health;

        Debug.Log("Health : " + health);
    }

    public void minusHealth(int index)
    {
        if (index < 0) return;
        animator.SetBool("isHit" , true);
        isHit = true;
        health -= index;
        if (health <= 0)
        {
            health = 0;
            objGameOver.SetActive(true);
            Time.timeScale = 0;
        }
        healthSlider.value = health;


        
        Debug.Log("Health : " + health);

    }

    public void addPoint()
    {
        point++;
        tPoint.text = point + "/10";
    }


}

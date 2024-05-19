using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public GameObject objMenu;
    
    private bool isEsc = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           setActiveMenu();
        }
    }

    public void setActiveMenu()
    {
        isEsc = !isEsc;
        objMenu.SetActive(isEsc);
        if (isEsc) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void restartGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        isEsc = false;
    }
}

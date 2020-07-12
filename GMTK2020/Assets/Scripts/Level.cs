using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Level : MonoBehaviour {
    [SerializeField] float delayTime = 2f;
	public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu"); 
    }
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options Menu"); 
    }
    public void LoadAccessibilityMenu()
    {
        SceneManager.LoadScene("Accessibility Menu"); 
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Level1");
        FindObjectOfType<GameSession>().ResetGame(); 
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad()); 
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Level : MonoBehaviour {
    [SerializeField] float delayTime = 2f;
	public void LoadStartMenu()
    {
        SceneManager.LoadScene(0); 
    }
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene(1); 
    }
    public void LoadAccessibilityMenu()
    {
        SceneManager.LoadScene(3); 
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(2);
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

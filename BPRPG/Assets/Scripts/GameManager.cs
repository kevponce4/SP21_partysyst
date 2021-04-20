using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    #region Unity_functions
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Scene_transitions
    public void TutorialLevel()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void JaneLevel()
    {
        SceneManager.LoadScene("level");
    }
    public void AbbyLevel()
    {
        SceneManager.LoadScene("Abby_level");
    }
    #endregion
}

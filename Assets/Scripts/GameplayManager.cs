using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }

    public Player Player;
    public MessageController Message;
    public CanvasGroup EndGameScreen;

    private bool gameEnd = false;

    private void Awake()
    {
        Instance = this;
        gameEnd = false;
        EndGameScreen.alpha = 0;
    }

    private void Update()
    {
        if(gameEnd && Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.isEditor)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void EndGame()
    {
        gameEnd = true;
        Player.UseMatchbox();
        Player.enabled = false;
        Message.gameObject.SetActive(false);
        StartCoroutine(EndGameAnimation());
    }

    private IEnumerator EndGameAnimation()
    {
        yield return new WaitForSeconds(2);
        Player.StandUp();
        float animationTime = 0.5f;
        for(float time = 0; time < animationTime; time+=Time.deltaTime)
        {
            EndGameScreen.alpha = time / animationTime;
            yield return 0;
        }
        EndGameScreen.alpha = 1;
    }
}
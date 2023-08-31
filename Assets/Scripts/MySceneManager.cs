using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject playerCharacter;
    public GameObject Credits;
    private Camera mainCamera;

    void Start()
    {
        Credits.SetActive(false);
        mainCamera = Camera.main;
        Debug.Log("Initial obj worldspace pos: "+ playerCharacter.transform.position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();

        else if (Input.GetKeyDown(KeyCode.C))
            ToggleCredits();

        else if (Input.GetKeyDown(KeyCode.Mouse0)){
            Vector3 pos = Input.mousePosition;
            RespawnBall(pos);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }

    // private void OnEnable()
    // {
    //     ZoneTriggers.OnObjEnteredWin += HandleObjectEnteredWinningZone;
    //     ZoneTriggers.OnObjEnteredLava += HandleObjectEnteredLavaZone;
    // }

    // private void OnDisable()
    // {
    //     ZoneTriggers.OnObjEnteredWin -= HandleObjectEnteredWinningZone;
    //     ZoneTriggers.OnObjEnteredLava -= HandleObjectEnteredLavaZone;
    // }

    // private void HandleObjectEnteredWinningZone(GameObject enteredObject)
    // {
    //     Debug.Log(enteredObject.name + " has entered the Winning Zone!");
    //     winningText.SetActive(true);
    //     retryPrompt.SetActive(true);
    //     playerCharacter.SetActive(false);
    //     winningParticles.SetActive(false);
    // }

    // private void HandleObjectEnteredLavaZone(GameObject enteredObject)
    // {
    //     Debug.Log(enteredObject.name + " dies on contact with lava.");
    //     losingText.SetActive(true);
    //     retryPrompt.SetActive(true);
    //     playerCharacter.SetActive(false);
    //     winningParticles.SetActive(false);
    // }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ToggleCredits()
    {   
        if (Credits.activeSelf)
            Credits.SetActive(false);
        else
            Credits.SetActive(true);
    }

    private void RespawnBall(Vector3 screenMousePos)
    {   
        // remove the active ball from screen first
        if (playerCharacter.activeSelf) 
            playerCharacter.SetActive(false);
        
        Vector2 mousePos2d = mainCamera.ScreenToWorldPoint(screenMousePos);
        Debug.Log("Screen space mouse position: " +screenMousePos);
        Debug.Log("World space mouse position: " +mousePos2d);
        playerCharacter.transform.position = new Vector2(mousePos2d.x, 7);
        playerCharacter.SetActive(true);
    }
}
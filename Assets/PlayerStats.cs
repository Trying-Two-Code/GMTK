using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public float health = 5f;
    [SerializeField] private GameObject DeathScreen;
    public void hurt(float amm)
    {
        health -= amm;
        if(health <= 1f)
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        DeathScreen.SetActive(true);
    }

    private void Update()
    {
        if(gameObject.transform.position.y > 0.94)
        {
            //ResetGame();
        }
    }

}

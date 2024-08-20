using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public float health = .3f;
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private GameObject HurtScreen;
    public void hurt(float amm)
    {
        Debug.Log("PLAYER HURT!");
        HurtScreen.SetActive(true);
        Invoke("notHurt", .1f);
        health -= amm * Time.deltaTime;
        if(health <= 1f)
        {
            ResetGame();
        }
    }

    private void notHurt()
    {
        HurtScreen.SetActive(false);
    }

    public void ResetGame()
    {
        DeathScreen.SetActive(true);
    }

    //private void Update()
    //{
    //    if(gameObject.transform.position.y > 0.94)
    //    {
    //        //ResetGame();
    //    }
    //}

}

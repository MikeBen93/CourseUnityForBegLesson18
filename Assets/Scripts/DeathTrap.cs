using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrap : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDeatheffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            StartCoroutine(DestroyAndReset(collision.gameObject));
        }
    }

    IEnumerator DestroyAndReset(GameObject player)
    {
        player.SetActive(false);

        Instantiate(playerDeatheffect, player.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(2f);
        Debug.Log(player.tag);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

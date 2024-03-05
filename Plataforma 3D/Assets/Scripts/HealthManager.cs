using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public float invencibilitylength;
    public float invencibilityCounter;

    public Renderer playerRenderer;
    public float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    public Vector3 respawnPoint;
    public float respawnLength;

    public PlayerMovement thePlayer;
    public GameObject playerInput;

    void Start()
    {
        currentHealth = maxHealth;

        respawnPoint = thePlayer.transform.position;
    }
    void Update()
    {
        if (invencibilityCounter > 0)
        {
            invencibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;

            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if (invencibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invencibilityCounter <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Respawn();
            }

            else
            {
                thePlayer.Knockback(direction);

                invencibilityCounter = invencibilitylength;

                playerRenderer.enabled = false;

                flashCounter = flashLength;
            }
        }
    }

    public void Respawn()
    {
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
    }

    public IEnumerator RespawnCo()
    {
        GameObject player = GameObject.Find("Player");
        CharacterController charController = player.GetComponent<CharacterController>();

        isRespawning = true;

        thePlayer.enabled = false;
        playerRenderer.enabled = false;
        charController.enabled = false;

        yield return new WaitForSeconds(respawnLength);

        isRespawning = false;

        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;
        charController.enabled = true;
        thePlayer.enabled = true;

        invencibilityCounter = invencibilitylength;

        playerRenderer.enabled = false;

        flashCounter = flashLength;
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}

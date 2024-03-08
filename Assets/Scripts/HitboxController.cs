using UnityEngine;
using System.Collections;

public class HitboxController : MonoBehaviour
{
    public PlayerAttack playerattack;
    public PlayerMovement playermovement;
    public PlayerHealth playerhealth;
    private bool hitDetected = false; 
    public int damageAmount = 10;
    public float hitStopDuration = 0.1f;
    public float hitStopTimeScale = 0.1f;

    public float hitStunDuration = 0.3f;
    public float hitStunTimeScale = 0.1f;

    void Start()
    {
       GameObject playerObject = GameObject.Find("PrototypeChar");
    if (playerattack == null)
    {
        Debug.LogError("PlayerAttack component not found on the HitboxController's GameObject.");
    }
    else
    {
        Debug.Log("PlayerAttack component found and assigned successfully.");
    }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!hitDetected && other.CompareTag("Player"))
        {
            Debug.Log("Hit Detected");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                StartCoroutine(HitStopCoroutine());
                ApplyHitStun(other.gameObject);
                playerattack.OnAttackInterrupted();
            }
            hitDetected = true;
            hitDetected = false;
        }
    }
   
    IEnumerator HitStopCoroutine()
    {
    Time.timeScale = hitStopTimeScale;
    yield return new WaitForSecondsRealtime(hitStopDuration);
    Time.timeScale = 1f;
    }

    void ApplyHitStun(GameObject player)
    {
    Debug.Log("Hitstun applied");
    PlayerAttack playerAttack = player.GetComponent<PlayerAttack>();
    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
    if (playerAttack != null && playerHealth.isAlive == true)
    {
        playerAttack.OnAttackInterrupted();
        playerAttack.ChangeAnimationState("gethit");
        StartCoroutine(HitStunCoroutine(playerAttack));
    }
    else
    {
        playerAttack.ChangeAnimationState("death");
    }
    }

IEnumerator HitStunCoroutine(PlayerAttack playerAttack)
{
    Time.timeScale = hitStunTimeScale;
    yield return new WaitForSecondsRealtime(hitStunDuration);
    playerAttack.ChangeAnimationState("idle");
    Time.timeScale = 1f;
}



}

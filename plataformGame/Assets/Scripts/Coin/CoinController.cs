using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private HUDCoins hudCoins;
    private AudioSource audioSource;

    private void Awake()
    {
        hudCoins = FindAnyObjectByType<HUDCoins>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hudCoins.totalCoins++;
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}

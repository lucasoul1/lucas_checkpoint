using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUDCoins : MonoBehaviour
{
    // Components
    private Text numberCoins;
    public int totalCoins;

    private void Awake()
    {
        numberCoins = GetComponent<Text>();
    }

    private void Update()
    {
        HUDUpdate();
    }

    private void HUDUpdate()
    {
        numberCoins.text = totalCoins.ToString();
    }
}

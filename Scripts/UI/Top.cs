using UnityEngine;
using UnityEngine.UI;

public class Top : MonoBehaviour
{
    [SerializeField] private Text coinText; 
    
    public void Init()
    {
        coinText.text = GameData.Instance.coinsCount.ToString();
    }
}
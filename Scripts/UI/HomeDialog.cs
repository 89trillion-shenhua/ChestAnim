using UnityEngine;

public class HomeDialog : MonoBehaviour
{
    [SerializeField] private Top coinText;

    void Awake()
    {
        var gameData = GameData.Instance;
        coinText.Init();
    }
}

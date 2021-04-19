using System;
using UnityEngine;
using UnityEngine.UI;

public class ChestItem : MonoBehaviour
{
    [SerializeField] private GameObject showChestDialog;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform fromTransform;
    [SerializeField] private CoinCollectionAnim coinPrefab;
    [SerializeField] private OpenChestDialog _openChestDialog;
    [SerializeField] private Text coinsCount;

    private int _clickCount;
    private int showCoinNumber;
    private const int MAXCount = 15;
    private Action callback;

    public void Init(int clickCount, Action action)
    {
        _clickCount = clickCount;
        callback = action;
    }

    public void OnBuyClick()
    {
        _clickCount += 1;
        showCoinNumber = 5 * _clickCount >= 15 ? MAXCount : 5 * _clickCount;
        GameData.Instance.ChangeCoinsData(5 * _clickCount);

        callback = () =>
        {
            CoinCollectionAnim.ShowCollectionAnim(fromTransform, targetTransform, coinPrefab, 
                coinsCount, showCoinNumber);
        };
        
        _openChestDialog.Init(showCoinNumber, callback);
    }

    public void AnimCallBack()
    {
        callback?.Invoke();
        showChestDialog.SetActive(false);
    }
}
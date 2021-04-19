using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System;

public class CoinCollectionAnim : MonoBehaviour
{
    public static void ShowCollectionAnim(Transform fromTransform, Transform targetTransform, 
        CoinCollectionAnim coinPrefab, Text text, int showCoinNumber)
    {
        Sequence mainSequence = DOTween.Sequence();
        for (int i = 0; i < showCoinNumber; i++)
        {
            mainSequence.AppendCallback((() =>
            {
                ShowSingleCoinAnim(fromTransform, targetTransform, coinPrefab);
            }));
            mainSequence.AppendInterval(0.1f);
        }

        mainSequence.AppendCallback((() =>
        {
            ShowCoinsPlusAnim(text);
        }));
    }

    private static void ShowSingleCoinAnim(Transform fromTransform, Transform targetTransform, 
        CoinCollectionAnim coinPrefab)
    {
        float scaleRate = 50f;
        float x = fromTransform.position.x + Random.Range(-1f, 1f);
        float y = fromTransform.position.y + Random.Range(-1f, 1f);
        Vector3 vector3 = new Vector3(x, y, 0);
        Sequence sequence = DOTween.Sequence();
        CoinCollectionAnim anim = Instantiate(coinPrefab, fromTransform);
        anim.transform.localScale *= scaleRate;
        sequence.Append(anim.transform.DOMove(vector3, 1f));
        sequence.Append(anim.transform.DOMove(targetTransform.position, 1f));
        sequence.AppendCallback(() =>
        {
            anim.gameObject.SetActive(false);
            Destroy(anim.gameObject, 0.5f);
        });
    }
    
    private static void ShowCoinsPlusAnim(Text text)
    {
        Sequence coinSequence = DOTween.Sequence();
        int startValue = Convert.ToInt32(text.text);
        int endValue = GameData.Instance.coinsCount;
        coinSequence.Append(DOTween.To(value =>
            {
                text.text = Mathf.Floor(value).ToString();
            }, 
            startValue, endValue: endValue, duration: 1f));
    }
}
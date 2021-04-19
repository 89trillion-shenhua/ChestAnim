using System;
using UnityEngine;
using UnityEngine.UI;

public class OpenChestDialog : MonoBehaviour
{
	[SerializeField] private GameObject showChestDialog;
	[SerializeField] private Transform targetTransform;
	[SerializeField] private Transform fromTransform;
	[SerializeField] private CoinCollectionAnim coinPrefab;
	[SerializeField] private Text coinsCount;
	[SerializeField] private Animator showChestAnim;
	[SerializeField] private ChestItem _chestItem;

	private int showCoinNumber;
	private Action callback;

	public void Init(int showCoinNumber, Action action)
	{
		this.showCoinNumber = showCoinNumber;
		callback = action;
		_chestItem.Init(showCoinNumber, callback);
		showChestDialog.SetActive(true);
	}

	void OnEnable()
	{
		showChestAnim.speed = 1;
		showChestAnim.SetTrigger("box_close_1");
	}

	public void OnBgClick()
	{
		CoinCollectionAnim.ShowCollectionAnim(fromTransform, targetTransform, coinPrefab, coinsCount, showCoinNumber);
		showChestDialog.SetActive(false);
	}
}
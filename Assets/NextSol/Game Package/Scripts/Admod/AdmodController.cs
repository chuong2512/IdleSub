using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdmodController : MonoBehaviour
{
	public static AdmodController instance;
	string                        App_ID="ca-app-pub-3321735106491906~1485382653";
	/*private BannerView bannerView;
	private InterstitialAd interstitial;
	private RewardedAd rewardedAd;*/
	// Start is called before the first frame update
	void Awake()
	{
		if(instance!=null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance=this;
			DontDestroyOnLoad(gameObject);
		}
	}
	void Start()
	{
		App_ID="ca-app-pub-3321735106491906~1485382653";
		/*MobileAds.Initialize(initStatus => { });*/
		RequestInterstitial();
		// RequestBanner();
		CreateAndLoadRewardedAd();
	}

	private void RequestBanner()
	{
#if UNITY_ANDROID
		string adUnitId="ca-app-pub-3321735106491906/9702768113";
#elif UNITY_IPHONE
        string adUnitId="ca-app-pub-3321735106491906/8379746450";
#else
        string adUnitId="unexpected_platform";
#endif

		/*
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

		// Called when an ad request has successfully loaded.
		bannerView.OnAdLoaded += HandleOnAdLoaded;
		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when an ad is clicked.
		bannerView.OnAdOpening += HandleOnAdOpened;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the banner with the request.
		bannerView.LoadAd(request);*/
	}
	private void RequestInterstitial()
	{
#if UNITY_ANDROID
		string adUnitId="ca-app-pub-3321735106491906/9319624734";
#elif UNITY_IPHONE
        string adUnitId="ca-app-pub-3321735106491906/4805664657";
#else
        string adUnitId="unexpected_platform";
#endif

		/*// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Called when an ad request has successfully loaded.
		interstitial.OnAdLoaded += HandleOnInterstitialAdLoaded;
		// Called when an ad request failed to load.
		interstitial.OnAdFailedToLoad += HandleOnAdInterstitialFailedToLoad;
		// Called when an ad is shown.
		interstitial.OnAdOpening += HandleOnInterstitialAdOpened;
		// Called when the ad is closed.
		interstitial.OnAdClosed += HandleOnInterstitialAdClosed;
		// Called when the ad click caused the user to leave the application.
		interstitial.OnAdLeavingApplication += HandleOnInterstitialAdLeavingApplication;
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);

		SendEventFirebase.EventFullAdsRequest();*/
	}
	public void ShowInterstitial()
	{
		/*if (interstitial.IsLoaded())
		{
		    interstitial.Show();
		}*/
	}
	public void CreateAndLoadRewardedAd()
	{
/*#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3321735106491906/7814971376";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3321735106491906/7240256303";
#else
        string adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);*/

	}
	/*#region ForEvent
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
	    print("HandleAdLoaded event received");
	}

	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
	    print("HandleFailedToReceiveAd event received with message: "
	                        + args.Message);
	}

	public void HandleOnAdOpened(object sender, EventArgs args)
	{
	    print("HandleAdOpened event received");
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
	    print("HandleAdClosed event received");
	}

	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
	    print("HandleAdLeavingApplication event received");
	}

	// InterstitialAd
	public void HandleOnInterstitialAdLoaded(object sender, EventArgs args)
	{
	    print("HandleAdLoaded event received");
	    // SendEventFirebase.EventFullAdsRequestSuccess();

	}

	public void HandleOnAdInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
	    print("HandleFailedToReceiveAd event received with message: "
	                        + args.Message);
	    // SendEventFirebase.EventFullAdsRequestFailed();
	}

	public void HandleOnInterstitialAdOpened(object sender, EventArgs args)
	{
	    print("HandleAdOpened event received");
	    //   SendEventFirebase.EventFullAdsShow();
	}

	public void HandleOnInterstitialAdClosed(object sender, EventArgs args)
	{
	    print("HandleAdClosed event received");
	    //   SendEventFirebase.EventFullAdsFinish();
	}

	public void HandleOnInterstitialAdLeavingApplication(object sender, EventArgs args)
	{
	    print("HandleAdLeavingApplication event received");
	}

	// Reward
	public void HandleRewardedAdClosed(object sender, EventArgs args)
	{
	    //fail?.Invoke();
	    if (_rewardOK)
	    {
	        complete?.Invoke();
	    }
	    else
	    {
	        fail?.Invoke();
	    }
	    _rewardOK = false;
	    //GameManager.Instance.isShowAds = false;
	    this.CreateAndLoadRewardedAd();
	    // SendEventFirebase.EventVideoAdsFinish();
	}
	public void HandleRewardedAdLoaded(object sender, EventArgs args)
	{
	    print("HandleRewardedAdLoaded event received");
	    //  SendEventFirebase.EventVideoAdsShowReady();
	}

	public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
	{
	    print(
	        "HandleRewardedAdFailedToLoad event received with message: "
	                         + args.Message);
	    //  SendEventFirebase.EventVideoAdsShowNotReady();
	}
	public void HandleRewardedAdOpening(object sender, EventArgs args)
	{
	    print("HandleRewardedAdOpening event received");
	    //  SendEventFirebase.EventVideoAdsShow();
	}

	public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
	{
	    print(
	        "HandleRewardedAdFailedToShow event received with message: "
	                         + args.Message);
	    //   SendEventFirebase.EventVideoAdsShowFailed();
	    // fail?.Invoke();
	}
	public void HandleUserEarnedReward(object sender, Reward args)
	{
	    string type = args.Type;
	    double amount = args.Amount;
	    print(
	        "HandleRewardedAdRewarded event received for "
	                    + amount.ToString() + " " + type);

	    _rewardOK = true;
	    //  SendEventFirebase.EventVideoAdsRewardReceived();
	}
	#endregion*/

	bool   _rewardOK=false;
	Action complete;
	Action fail;

	public void ShowWitchCallback(Action _complete,Action _fail)
	{
#if UNITY_ANDROID
		GameManager.Instance.isShowAds=true;
#endif
		this.complete=_complete;
		this.fail    =_fail;
		UserChoseToWatchAd();
	}

	private void UserChoseToWatchAd()
	{
		/*if (this.rewardedAd.IsLoaded())
		{
		    this.rewardedAd.Show();
		}
		else*/
		{
			GameUIManager.Instance.popupNoads.SetActive(true);
			Invoke("AutoHidenPopup",3f);
		}
	}

	public void AutoHidenPopup() { GameUIManager.Instance.popupNoads.SetActive(false); }
}

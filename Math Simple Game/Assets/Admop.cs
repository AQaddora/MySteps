using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class Admop : MonoBehaviour
{
	public static Admop Instance;
	public static bool isInitialized = false;
	[HideInInspector] public bool isQuitting = false;

	[Header("ﺐﻳﺮﺠﺘﻟﺍ ﺽﺮﻐﻟ ﺭﺎﻴﺨﻟﺍ ﺍﺬﻫ ﻢّﻠﻋ")]
	public bool isTesting = false;

	[Header("time in seconds, ﻲﻧﺍﻮﺜﻟﺎﺑ ﻲﻨﻴﺒﻟﺍ ﺖﻗﻮﻟﺍ")]
	public float intervalInSeconds = 120;

	private BannerView bannerView;
	public InterstitialAd interstitial;

	[Header("App ID")]
	[SerializeField] private string appIDAndroid = "";
	[SerializeField] private string appIDIOS = "";
	[Space]
	[Header("AdUnits Android")]
	[SerializeField] private string bannerID = "";
	[SerializeField] private string interstitialID = "";

	[Space]
	[Header("AdUnits iOS")]
	[SerializeField] private string bannerIDIOS = "";
	[SerializeField] private string interstitialIDIOS = "";
	void Start()
	{

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this);
		}
		else if (Instance != null)
		{
			Destroy(this);
		}

		string appID = "";
#if UNITY_ANDROID
		appID = appIDAndroid;
#elif UNITY_IPHONE
		appID = appIDIOS;
#else
		appID = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize (initStatus => { });
        RequestBanner();
        RequestInterstitial ();
	}
	TimeSpan tsOld;
	public void ShowInterstitial()
	{
		TimeSpan tsNow = TimeSpan.FromTicks(DateTime.Now.Ticks);
		double totalSeconds = tsNow.TotalSeconds - tsOld.TotalSeconds;
		Debug.Log(totalSeconds);
		if (interstitial.IsLoaded() && totalSeconds > intervalInSeconds)
		{
			tsOld = TimeSpan.FromTicks(DateTime.Now.Ticks);
			interstitial.Show();
		}
	}

	private void RequestBanner()
	{
#if UNITY_ANDROID
		string adUnitId = bannerID;
#elif UNITY_IPHONE
		string adUnitId = bannerIDIOS;
#else
		string adUnitId = "unexpected_platform";
#endif
		if (isTesting) adUnitId = "ca-app-pub-3940256099942544/6300978111";
		
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

		// Called when an ad request has successfully loaded.
		bannerView.OnAdLoaded += HandleOnbannerViewLoaded;
		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleOnbannerFailedToLoad;
		// Called when an ad is clicked.
		bannerView.OnAdOpening += HandleOnbannerOpened;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleOnbannerClosed;
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	public void HandleOnbannerViewLoaded(object sender, EventArgs args)
	{
		ShowBanner();
		Debug.Log("HandleOn banner ViewLoaded event received");
	}

	public void HandleOnbannerFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Debug.Log("HandleOn banner FailedToLoad");
		RequestBanner ();
	}

	public void HandleOnbannerOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleOn banner Opened event received");
	}

	public void HandleOnbannerClosed(object sender, EventArgs args)
	{
		Debug.Log("HandleOn banner Closed");
		//RequestBanner ();
	}

	public void HandleOnbannerLeavingApplication(object sender, EventArgs args)
	{
		Debug.Log("HandleOnbannerLeavingApplication event received");
	}


	private void RequestInterstitial()
	{
		Debug.Log("RequestInterstitial()");
#if UNITY_ANDROID
		string adUnitId = interstitialID;
#elif UNITY_IPHONE
		string adUnitId = interstitialID;
#else
		string adUnitId = "unexpected_platform";
#endif
		if (isTesting) adUnitId = "ca-app-pub-3940256099942544/8691691433";
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);


		// Called when an ad request has successfully loaded.
		interstitial.OnAdLoaded += HandleOninterstitialLoaded;
		// Called when an ad request failed to load.
		interstitial.OnAdFailedToLoad += HandleinterstitialAdFailedToLoad;
		// Called when an ad is shown.
		interstitial.OnAdOpening += HandleinterstitialAdOpened;
		// Called when the ad is closed.
		interstitial.OnAdClosed += HandleinterstitialAdClosed;
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	public void HandleOninterstitialLoaded(object sender, EventArgs args)
	{
		Debug.Log("HandleOn interstitial Loaded event received");
	}

	public void HandleinterstitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Debug.Log("Handle interstitial AdFailedToLoad");
		RequestInterstitial ();
	}

	public void HandleinterstitialAdOpened(object sender, EventArgs args)
	{
		if (isQuitting)
		{
			Application.Quit();
			Debug.Log("Quit!");
		}
		Debug.Log("Handle interstitial AdOpened event received");
	}

	public void HandleinterstitialAdClosed(object sender, EventArgs args)

	{
		Debug.Log("HandleinterstitialAdClosed");
		if (isQuitting)
		{
			Application.Quit();
			Debug.Log("Quit!");
		}
		RequestInterstitial();
	}

	public void HandleinterstitialAdLeavingApplication(object sender, EventArgs args)
	{
		if (isQuitting)
		{
			Application.Quit();
			Debug.Log("Quit!");
		}
		Debug.Log("Handle interstitial AdLeavingApplication event received");
	}


	public void ShowBanner()
	{
		try
		{
			bannerView.Show();

		}
		catch (System.Exception)
		{
		}

	}
	public void HideBanner()
	{
		try
		{
			bannerView.Hide();
		}
		catch (System.Exception)
		{
		}
	}
}

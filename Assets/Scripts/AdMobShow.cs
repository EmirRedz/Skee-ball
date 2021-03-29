using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobShow : MonoBehaviour
{

    private string APP_ID = "ca-app-pub-7416398326663973~7838924350";
    private InterstitialAd interstitialAd;
    private BannerView bannerAD;
    private RewardBasedVideoAd adReward;
    string idReward;



    private void Awake()
    {


        int numOfGameData = FindObjectsOfType<AdMobShow>().Length;

        if (numOfGameData != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            MobileAds.Initialize(APP_ID);
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial();
        DontDestroyOnLoad(this);

        idReward = "ca-app-pub-7416398326663973/7072637591";
        adReward = RewardBasedVideoAd.Instance;



    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            //GameData.SaveAllData();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    void RequestInterstitial()
    {
        //normal ca-app-pub-7416398326663973/4427192417


        string insterstitial_ID = "ca-app-pub-7416398326663973/3376935160";
        interstitialAd = new InterstitialAd(insterstitial_ID);


        //AdRequest adRequest = new AdRequest.Builder()
        //.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();


        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);

        interstitialAd.OnAdClosed += this.HandleOnAdClosed;


    }

    public void RequestRewardAd()
    {
        Debug.Log("request ad");
        AdRequest request = AdRequestBuild();

        adReward.LoadAd(request, idReward);


        adReward.OnAdLoaded += this.HandleOnRewardedAdLoaded;
        adReward.OnAdRewarded += this.HandleOnAdRewarded;
        adReward.OnAdClosed += this.HandleOnRewardedAdClosed;
    }


    public void DisplayInterstitial()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }

    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }



    public void ShowRewardAd()
    {
        if (adReward.IsLoaded())
            adReward.Show();
    }

    public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
    {//ad loaded
        ShowRewardAd();
    }

    public void HandleOnAdRewarded(object sender, EventArgs args)
    {//user finished watching ad
        //GameData.AddToRewardedCount();
        WatchFullAd();
    }

    public void WatchFullAd()
    {
        PlayerPrefs.SetInt("TotalTickets", PlayerPrefs.GetInt("TotalTickets") + 85);
    }

    public void HandleOnRewardedAdClosed(object sender, EventArgs args)
    {


        adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        adReward.OnAdRewarded -= this.HandleOnAdRewarded;
        adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {//oq rola qnd o banner é aberto
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {//qnd ele termina o ad
        MonoBehaviour.print("HandleAdClosed event received");
        RequestInterstitial();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {//ngm se importa
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }





}

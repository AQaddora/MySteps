using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
	private static bool isFirstTime = true;

	[Header("Faders")]
	public Fader loading;
	public Fader loginFader, registerFader, blackImage, wholePanelFader;

	[Header("Login Inputs")]
	public InputField emailInputLogin;
	public InputField passwordInputLogin;
	[Header("Register Inputs")]
	public InputField emailInputReg;
	public InputField passwordInputReg, usernameInputReg;


	private string email, password, username;
	public void Start()
	{
		if (isFirstTime)
		{
			isFirstTime = false;
			if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
			{
				PlayFabSettings.TitleId = "CED75"; 
			}

			if (PlayerPrefs.HasKey("EMAIL"))
			{
				wholePanelFader.cg.alpha = 0;
				wholePanelFader.cg.blocksRaycasts = false;
				blackImage.cg.alpha = 0;
				blackImage.cg.blocksRaycasts = false;
				loading.cg.blocksRaycasts = false;
				loading.cg.blocksRaycasts = false;
				NotificationManager.Instance.ShowNotification("تسجيل الدخول", "جار تسجيل دخولك إلى التطبيق", true, 6);
				loading.Show();
				blackImage.Show();
				email = PlayerPrefs.GetString("EMAIL");
				password = PlayerPrefs.GetString("PASSWORD");
				var request = new LoginWithEmailAddressRequest { Email = email, Password = password};
				PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
			}
		}
		else
		{
			wholePanelFader.cg.alpha = 0;
			wholePanelFader.cg.blocksRaycasts = false;
			blackImage.cg.alpha = 0;
			blackImage.cg.blocksRaycasts = false;
			loading.cg.blocksRaycasts = false;
			loading.cg.blocksRaycasts = false;
		}
	}

	public void LoginOnClick()
	{
		if (string.IsNullOrEmpty(emailInputLogin.text) || string.IsNullOrEmpty(passwordInputLogin.text))
		{
			NotificationManager.Instance.ShowNotification("تسجيل الدخول", "عليك ملئ جميع الحقول", true);
			return;
		}
		loading.Show();
		email = emailInputLogin.text;
		password = passwordInputLogin.text;
		var request = new LoginWithEmailAddressRequest { Email = email, Password = password };
		PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
	}
	public void RegisterOnClick()
	{
		if (string.IsNullOrEmpty(usernameInputReg.text) || string.IsNullOrEmpty(emailInputReg.text) || string.IsNullOrEmpty(passwordInputReg.text))
		{
			NotificationManager.Instance.ShowNotification("تسجيل الدخول", "عليك ملئ جميع الحقول", true);
			return;
		}
		loading.Show();
		username = usernameInputReg.text;
		email = emailInputReg.text;
		password = passwordInputReg.text;
		var request = new RegisterPlayFabUserRequest { Email = email, Password = password , Username = username};
		PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
	}
	#region callbacks
	private void OnLoginSuccess(LoginResult result)
	{
		NotificationManager.Instance.ShowNotification("تسجيل الدخول", "تم تسجيل دخولك بنجاح", false);
		Debug.Log("LOGGED IN as: " + email);
		PlayerPrefs.SetString("EMAIL", email);
		PlayerPrefs.SetString("PASSWORD", password);
		wholePanelFader.Hide();
		blackImage.Hide();
		loading.Hide();
	}
	private void OnLoginFailure(PlayFabError error)
	{
		NotificationManager.Instance.ShowNotification("لم يتم تسجيل الدخول", "تحقق من البيانات", true);
		if(blackImage.cg.alpha > 0.5f) blackImage.Hide();
		if (loading.cg.alpha > 0.5f) loading.Hide();
		Debug.LogWarning("Something went wrong with your first API call.  :(");
		Debug.LogError(error.GenerateErrorReport());
	}
	private void OnRegisterSuccess(RegisterPlayFabUserResult result)
	{
		NotificationManager.Instance.ShowNotification("التسجيل", "تم التسجيل بنجاح", false);
		Debug.Log("REGISTERED as:" + email);
		PlayerPrefs.SetString("EMAIL", email);
		PlayerPrefs.SetString("PASSWORD", password);
		wholePanelFader.Hide();
		blackImage.Hide();
		loading.Hide();
	}
	private void OnRegisterFailure(PlayFabError error)
	{
		NotificationManager.Instance.ShowNotification("لم يتم التسجيل", "تحقق من البيانات", true);
		blackImage.Hide();
		loading.Hide(); Debug.LogWarning("Something went wrong with your first API call.  :(");
		Debug.LogError(error.GenerateErrorReport());
	}
	#endregion
}
using PlayFab;
using PlayFab.ClientModels;

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabController : MonoBehaviour
{
    public static PlayFabController PFC;
    private string userEmail;
    private string userPassword;
    private string username;
    public GameObject loginPanel;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject creditsButton;
    public Text instruction;
    public Text inUse;

    private void OnEnable()
    {
        if (PlayFabController.PFC == null)
        {
            PlayFabController.PFC = this;
        }
        else
        {
            if (PlayFabController.PFC != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        creditsButton.SetActive(false);

        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "1C88A"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        PlayerPrefs.DeleteAll(); //to relog in everytime you restart the game. 
        //var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");
            var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

        }

    }

    internal static void SendLeaderboard(float actualScore)
    {
        throw new NotImplementedException();
    }

    internal static void SendLeaderboard(Text highScore)
    {
        throw new NotImplementedException();
    }

    #region login
    private void OnLoginSuccess(LoginResult result)
    {
        instruction.text = "Congratulations, you have logged in successfully!";

        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        loginPanel.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        creditsButton.SetActive(true);
        GetStats();
        GetLevel(); 
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        instruction.text = "Congratulations, you have successfully registered an account!";
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        GetStats();
        GetLevel();
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = username }, OnDisplayName, OnLoginFailure);

        loginPanel.SetActive(false);
        playButton.SetActive(true);
        quitButton.SetActive(true);
        creditsButton.SetActive(true);
    }

    void OnDisplayName(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log(result.DisplayName + " is your new display name");
    }
    private void OnLoginFailure(PlayFabError error)
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail, Password = userPassword, Username = username };
        inUse.text = "Username in use.Please try another name.";
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        inUse.text = "Password must be between 6 and 100 characters. Email must also be valid. Please try again.";


    }



    public void GetUserEmail(string emailIn)
    {
        userEmail = emailIn;
    }

    public void GetUserPassword(string passwordIn)
    {
        userPassword = passwordIn;
    }

    public void GetUsername(string usernameIn)
    {
        username = usernameIn;
    }

    public void OnClickLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    #endregion login

    public int playerLevel;

    public int playerHighScore;

    #region PlayerStats

    public void SetStats()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
            Statistics = new List<StatisticUpdate> {
        new StatisticUpdate { StatisticName = "PlayerLevel", Value = playerLevel },
        new StatisticUpdate { StatisticName = "PlayerHighScore", Value = playerHighScore },
            }
        },
        result => { Debug.Log("User statistics updated"); },
        error => { Debug.LogError(error.GenerateErrorReport()); });
    }

    void GetStats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStats,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnGetStats(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);
            switch (eachStat.StatisticName)
            {
                case "PlayerLevel":
                    playerLevel = eachStat.Value;
                    break;
                case "PlayerHighScore":
                    playerHighScore = eachStat.Value;
                    break;
            }
        }
    }
    // Build the request object and access the API
    public void StartCloudUpdatePlayerStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new { Level = playerLevel, highScore = playerHighScore }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateStats, OnErrorShared);
    }
    // OnCloudHelloWorld defined in the next code block

    private static void OnCloudUpdateStats(ExecuteCloudScriptResult result)
    {
        // CloudScript returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        //Debug.Log(JsonWrapper.SerializeObject(result.FunctionResult));
        //JsonObject jsonResult = (JsonObject)result.FunctionResult;
        //object messageValue;
        //jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in CloudScript
        //Debug.Log((string)messageValue);
    }

    private static void OnErrorShared(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion PlayerStats

    #region Leaderboard
    public void GetLeaderboarder()
    {
        var requestLeaderboard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "PlayerHighScore", MaxResultsCount = 10 };
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeadboard, OnErrorLeaderboard);
    }

    void OnGetLeadboard(GetLeaderboardResult result)
    {
        foreach (PlayerLeaderboardEntry player in result.Leaderboard)
        {
            Debug.Log(player.DisplayName + ": " + player.StatValue);
        }
    }

    void OnErrorLeaderboard(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlayerHighScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnErrorLeaderboard);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful leaderboard sent");
    }
    #endregion Leaderboard

    public ScoreManager scoreManager;
    public LevelManager levelManager;

    public void SaveLevel()
    {
        var request2 = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "HighScore", scoreManager.score.ToString() }
            }
        };
        PlayFabClientAPI.UpdateUserData(request2, OnDataSend, OnError);
    }

    public void GetLevel()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Received data successfully!");
        if (result.Data != null && result.Data.ContainsKey("HighScore"))
        {
            scoreManager.score.ToString(result.Data["HighScore"].Value);
        }else
        {
            Debug.Log("Player data not complete!");
        }
    }
    private void OnDataSend(UpdateUserDataResult obj)
    {
        throw new NotImplementedException();
    }

    void OnDataSend(UpdateUserDataRequest result)
    {
        Debug.Log("Successful user data send!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error saving data.");
    }
}


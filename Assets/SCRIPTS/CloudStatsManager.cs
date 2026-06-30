using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CloudStatsManager : MonoBehaviour
{
    private string apiURL = "https://4kbub5enwb.execute-api.us-east-1.amazonaws.com/production/ping";

    public int totalKills;
    public int totalSessions;

    private void Start()
    {
        totalSessions++;
        SendStats();
    }

    public void SendStats()
    {
        StartCoroutine(PostStats());
    }

    IEnumerator PostStats()
    {
        StatsData data = new StatsData();

        data.totalKills = totalKills;
        data.totalSessions = totalSessions;

        string jsonData = JsonUtility.ToJson(data);

        UnityWebRequest request = new UnityWebRequest(apiURL, "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Stats uploaded successfully");
            Debug.Log(request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Upload failed: " + request.error);
        }
    }
}

[System.Serializable]
public class StatsData
{
    public int totalKills;
    public int totalSessions;
}
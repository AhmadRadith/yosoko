using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;
//release
public class MainData
{
    public string release { get; set; }
}
public class ExampleScript : MonoBehaviour
{
    void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "maindata.json");

        if (!File.Exists(filePath))
        {
            Debug.LogError("maindata.json not found in StreamingAssets folder!");
            return;
        }

        string jsonData = File.ReadAllText(filePath);

        try
        {
            JObject data = JObject.Parse(jsonData);

            if (data != null)
            {
                Debug.Log(data.ToString());
                Debug.Log($"Release: {data["release"]}");
            }
            else
            {
                Debug.LogError("Error parsing maindata.json!");
            }
        }
        catch (JsonException ex)
        {
            Debug.LogError($"Error reading maindata.json: {ex.Message}");
        }
        //string[] files = Directory.GetDirectories(Application.streamingAssetsPath);
        //print(Application.dataPath);
        //print(files);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

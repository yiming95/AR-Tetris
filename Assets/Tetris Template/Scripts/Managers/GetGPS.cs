using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class GetGPS : MonoBehaviour
{

    string GetGps = "";
    public static float x;
    public static float y;

    public Text ShowGPS;

    /// <summary>  

    /// Initialize a position 

    /// </summary>  

    void Start()

    {

        StartCoroutine(StartGPS());

        if (x == 0 || y == 0)
        {
            GetGps = "GPS unavailable";
            GameObject.Find("MyRegion").GetComponent<Text>().text = "";
        }
        else
        {
            GetGps = "N:" + Input.location.lastData.latitude + " E:" + Input.location.lastData.longitude;
        }

        ShowGPS.text = GetGps;

        Debug.Log(GetGps);

    }

    /// <summary>  

    /// Refresh location information (button click event)  

    /// </summary>  

    public void updateGps()

    {

        StartCoroutine(StartGPS());

        x = Input.location.lastData.latitude;
        y = Input.location.lastData.longitude;

        if (x == 0 || y == 0)
        {
            GetGps = "GPS unavailable";
            GameObject.Find("MyRegion").GetComponent<Text>().text = "";
        }
        else
        {
            GetGps = "N:" + Input.location.lastData.latitude + " E:" + Input.location.lastData.longitude;
        }

        ShowGPS.text = GetGps;

        Debug.Log(GetGps);

    }

    /// <summary>  

    /// Stop refreshing the location (saving mobile phone power)  

    /// </summary>  

    void StopGPS()

    {

        Input.location.Stop();

    }

    IEnumerator StartGPS()

    {

        // Input.location - Location attribute for accessing the device (handheld device), static LocationService location    

        // LocationService.isEnabledByUser - Whether the location service in the user settings is enabled 

        if (!Input.location.isEnabledByUser)

        {

            GetGps = "isEnabledByUser value is:" + Input.location.isEnabledByUser.ToString() + " Please turn on the GPS";

            yield return false;

        }

        // LocationService.Start() - Start location service update, the last position coordinate will be used   

        Input.location.Start(10.0f, 10.0f);

        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)

        {

            // Suspend execution of the coroutine (1 second)   

            yield return new WaitForSeconds(1);

            maxWait--;

        }

        if (maxWait < 1)

        {

            GetGps = "Init GPS service time out";

            yield return false;

        }

        if (Input.location.status == LocationServiceStatus.Failed)

        {

            GetGps = "Unable to determine device location";

            yield return false;

        }

        else

        {

            float x = Input.location.lastData.latitude;
            float y = Input.location.lastData.longitude;

            if (x == 0 || y == 0)
            {
                GetGps = "GPS unavailable";
                GameObject.Find("MyRegion").GetComponent<Text>().text = "";
            }
            else
            {
                GetGps = "N:" + Input.location.lastData.latitude + " E:" + Input.location.lastData.longitude;
            }
            Debug.Log("Keyidingwei");

            yield return new WaitForSeconds(100);

        }

    }

}
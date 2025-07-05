using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThankyouController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdmodController.instance.ShowInterstitial();
        StartCoroutine(QuitGame(5));
    }

    IEnumerator QuitGame(float time)
    {
        yield return new WaitForSeconds(time);
        Application.Quit();
    }
}

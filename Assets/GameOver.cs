using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public GameObject DeathPi;
    // Use this for initialization
    void Start () {
      DeathPi.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }


}

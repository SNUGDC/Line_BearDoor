using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
    
    public Image pause_popup;
    public Text countdown;
    public Button leavebutton;
    public bool isStoped = false;
    TestByMouse mouseTest;
    DoorSpawn doorspawn;

    Scene currentscene;

	void Start()
    {
        mouseTest = GetComponent<TestByMouse>();
        doorspawn = GetComponent<DoorSpawn>();

		currentscene = SceneManager.GetActiveScene();
        if (currentscene.name == "testscene")
        {
            doorspawn.Initialize();
            StopWorld();
            StartCoroutine(Countdown());
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void OpenPopup()
	{
		StopWorld();
		Debug.Log("Open popup called");
	}

	public void ClosePopup()
    {
        StartCoroutine(Countdown());
        Debug.Log("Close popup called");
    }

    public IEnumerator Countdown()
    {
        int i = 3;
        float wait = 1.0f;

        mouseTest.swipeDirection = SwipeDirectionbyMouse.NONE;
        countdown.gameObject.SetActive(true);
        while (i>0)
        {
            countdown.text = i.ToString();
            i--;
            yield return new WaitForRealSeconds(wait);
        }
        if (i == 0)
		{
			countdown.gameObject.SetActive(false);
			//      Time.timeScale = 1;
			ResumeWorld();
		}
	}

	void StopWorld()
	{
		mouseTest.enabled = false;
		doorspawn.enabled = false;
		if (doorspawn.newDoor != null)
		{
			doorspawn.newDoor.GetComponent<DoorMover>().enabled = false;
		}
        isStoped = true;
	}

	void ResumeWorld()
	{
		mouseTest.enabled = true;
		doorspawn.enabled = true;
		if (doorspawn.newDoor != null)
		{
			doorspawn.newDoor.GetComponent<DoorMover>().enabled = true;
		}
        isStoped = false;
	}
}

public class WaitForRealSeconds : CustomYieldInstruction
{
    private float m_FinishTime;

    public WaitForRealSeconds(float seconds)
    {
        m_FinishTime = seconds + Time.realtimeSinceStartup;
    }

    public override bool keepWaiting
    {
        get
        {
            return m_FinishTime > Time.realtimeSinceStartup;
        }
    }
} // Additional WaitForSeconds Class by realtime
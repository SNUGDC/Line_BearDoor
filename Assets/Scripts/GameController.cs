using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelContext
{
    public float Doorspeed { get; set; }
    public float initialSpeed;
    public float Hunger;

    public int combo = 0;

    public LevelContext(float speed, float hp)
    {
        this.Doorspeed = speed;
        initialSpeed = speed;
        this.Hunger = hp;
    }

    public void IncreaseLevel()
    {
        if (combo < 10)
        {
            this.combo++;
        }

        Doorspeed = initialSpeed + combo / 5 * initialSpeed * 0.5f;
        Debug.Log(combo);
    }
    public void ResetLevel()
    {
        combo = 0;
        Doorspeed = initialSpeed;
        Hunger -= 100;
        Debug.Log(combo);
    }
}

public class GameController : MonoBehaviour {

    public GameObject[] Bear;

    public Text countdown;
    public Image pause_popup;
    public Button leavebutton;
    public Text scoreText;
    public Text gameoverText;
    public Text BestScore;
    public float score;
    public bool isStoped = false; //for Debugging

    private Button pausebutton;
    private int BearNumber;

    SwipeManager mouseTest;
    DoorSpawn doorspawn;
    TreeSpawn treespawn;
    RoadSpawn roadspawn;

    Scene currentscene;
    public LevelContext currentLevel;

    public static GameController Instance;

    public float initialDoorSpeed;
    public float initialHp;

	void Awake()
    {
        Instance = this;

        BearNumber = PlayerPrefs.GetInt("Bear Number");
        switch (BearNumber)
        {
            case 0:
                Bear[1].SetActive(false);
                Bear[2].SetActive(false);
                Bear[3].SetActive(false);
                break;
            case 1:
                Bear[0].SetActive(false);
                Bear[2].SetActive(false);
                Bear[3].SetActive(false);
                break;
            case 2:
                Bear[0].SetActive(false);
                Bear[1].SetActive(false);
                Bear[3].SetActive(false);
                break;
            case 3:
                Bear[0].SetActive(false);
                Bear[1].SetActive(false);
                Bear[2].SetActive(false);
                break;
            default:
                Debug.Log("Something is Wrong");
                break;
        }

        mouseTest = GetComponent<SwipeManager>();
        doorspawn = GetComponent<DoorSpawn>();
        treespawn = GetComponent<TreeSpawn>();
        roadspawn = GetComponent<RoadSpawn>();
        currentLevel = new LevelContext(initialDoorSpeed, initialHp);

        pausebutton = GameObject.Find("Pause_Button").GetComponent<Button>();
        
        scoreText.text = "0";
        gameoverText.text = "0";

        currentscene = SceneManager.GetActiveScene();
        if (currentscene.name == "Game")
        {
            doorspawn.Initialize();
            StopWorld();
            StartCoroutine(Countdown());
        }
    }

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
        Bear[BearNumber].GetComponent<Animator>().enabled = false;
        while (i>0)
        {
            countdown.text = i.ToString();
            i--;
            yield return new WaitForRealSeconds(wait);
        }
        if (i == 0)
		{
			countdown.gameObject.SetActive(false);
            Bear[BearNumber].GetComponent<Animator>().enabled = true;
            ResumeWorld();
		}
	}

	void StopWorld()
	{
		mouseTest.enabled = false;
		doorspawn.enabled = false;
        treespawn.enabled = false;
        roadspawn.enabled = false;
        pausebutton.enabled = false;
		if (doorspawn.newDoor != null)
		{
			doorspawn.newDoor.GetComponent<DoorMover>().enabled = false;
        }
        if(GameObject.FindGameObjectsWithTag("Tree") != null)
        {
            GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
            for(int i=0; i < trees.Length; i++)
            {
                trees[i].GetComponent<TreeController>().enabled = false;
            }
        }
        isStoped = true;
	}

	void ResumeWorld()
	{
		mouseTest.enabled = true;
		doorspawn.enabled = true;
        treespawn.enabled = true;
        roadspawn.enabled = true;
        pausebutton.enabled = true;
        if (doorspawn.newDoor != null)
		{
			doorspawn.newDoor.GetComponent<DoorMover>().enabled = true;
        }
        if (GameObject.FindGameObjectsWithTag("Tree") != null)
        {
            GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i].GetComponent<TreeController>().enabled = true;
            }
        }
        isStoped = false;
	}
    
    public void AddScore(SwipeDirectionbyMouse dir)
    {
        if (GetComponent<DoorSpawn>().newDoor.isReverseDoor == false) // reverse door 이 아닐 경우
        {
            if (dir == SwipeDirectionbyMouse.LEFT)
            {
                score += ((Instance.currentLevel.combo / 5) + 1) * 50;
            }
            else if (dir == SwipeDirectionbyMouse.RIGHT)
            {
                score += ((Instance.currentLevel.combo / 5) + 1) * 50;
            }
            else if (dir == SwipeDirectionbyMouse.UP)
            {
                score += ((Instance.currentLevel.combo / 5) + 1) * 50;
            }
            else if (dir == SwipeDirectionbyMouse.ClockWise)
            {
                score += ((Instance.currentLevel.combo / 5) + 1) * 200;
            }
            else if (dir == SwipeDirectionbyMouse.CounterClockWise)
            {
                score += ((Instance.currentLevel.combo / 5) + 1) * 200;
            }
        }
        else //reverse door일 경우
        {
            if (dir == SwipeDirectionbyMouse.RIGHT)
            {
                score += ((Instance.currentLevel.combo / 5) + 1) * 100;
            }
            else if (dir == SwipeDirectionbyMouse.LEFT)
            {
                score += ((Instance.currentLevel.combo / 5) + 1) * 100;
            }
            else if (dir == SwipeDirectionbyMouse.DOWN)
            {
                score += ((Instance.currentLevel.combo / 5) + 1) * 100;
            }
        }
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = " " + score;
        gameoverText.text = score.ToString();

        if (PlayerPrefs.HasKey("Best Score"))
        {
            if (PlayerPrefs.GetInt("Best Score") < score)
            {
                PlayerPrefs.SetInt("Best Score", (int)score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Best Score", (int)score);
        }

        BestScore.text = PlayerPrefs.GetInt("Best Score").ToString();
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("Start");
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
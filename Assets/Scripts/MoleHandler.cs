using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MoleHandler : MonoBehaviour
{

    public GameObject puzzlecompleto, Slot;


    AudioSource audioSource;

    [SerializeField] private List<Mole> moles;
    [Header("UI objects")]
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject outOfTimeText;
    [SerializeField] private GameObject WonText;
    [SerializeField] private GameObject bombText;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    //Sound
    [SerializeField] AudioClip topos;
    [SerializeField] AudioClip wrong_topos;
    [SerializeField] AudioClip win;

    // Hardcoded variables you may want to tune.
    private float startingTime = 60f;

    // Global variables
    private float timeRemaining;
    private HashSet<Mole> currentMoles = new HashSet<Mole>();
    private int score;
    private bool playing = false;




    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Slot = GameObject.FindGameObjectWithTag("Slot");

       
        // Ocultar la interfaz de usuario del juego Topos
        //gameUI.SetActive(false);

        // Iniciar el juego automáticamente topos
        //StartGame();
    }

    // Start is called before the first frame update
    void Start()
    {


        StartGame();

        // Hide/show the UI elements we don't/do want to see.
        gameUI.SetActive(true);
        // Hide all the visible moles.
        for (int i = 0; i < moles.Count; i++) {
            moles[i].Hide();
            moles[i].SetIndex(i);
        }
        // Remove any old game state.
        currentMoles.Clear();
        // Start with 30 seconds.
        timeRemaining = startingTime;
        score = 0;
        scoreText.text = "0";
        playing = true;
    }

    public void StartGame() 
    {
      // Hide/show the UI elements we don't/do want to see.
      gameUI.SetActive(true);
      // Hide all the visible moles.
      for (int i = 0; i < moles.Count; i++) {
        moles[i].Hide();
        moles[i].SetIndex(i);
      }
      // Remove any old game state.
      currentMoles.Clear();
      // Start with 30 seconds.
      timeRemaining = startingTime;
      score = 0;
      scoreText.text = "0";
      playing = true;
    }

    
    public void GameOver(int type) {

        // Show the message.
        if (type == 0) {
        outOfTimeText.SetActive(true);
        } else {
        bombText.SetActive(true);
        }
        // Hide all moles.
        foreach (Mole mole in moles) {
        mole.StopGame();
        audioSource.PlayOneShot(wrong_topos);
        Invoke ("Recargar", 2);
        }
        // Stop the game and show the start UI.
        playing = false;
        
    }


    // Update is called once per frame
    void Update()
    {
        //topos
        if (playing) {
            
            // Update time.
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0) {
                timeRemaining = 0;
                GameOver(0);
            }

            timeText.text = $"{(int)timeRemaining / 60}:{(int)timeRemaining % 60:D2}";
            // Check if we need to start any more moles.

            if (currentMoles.Count <= (score / 10)) {
                // Choose a random mole.
                int index = Random.Range(0, moles.Count);
                // Doesn't matter if it's already doing something, we'll just try again next frame.
                if (!currentMoles.Contains(moles[index])) {
                currentMoles.Add(moles[index]);
                moles[index].Activate(score / 10);
                }
            }
        }
    }

    
    public void AddScore(int moleIndex) {
            
        // Add and update score.
        score += 1;
        audioSource.PlayOneShot(topos);
        scoreText.text = $"{score}";
        // Increase time by a little bit.
        // Remove from active moles.
        currentMoles.Remove(moles[moleIndex]);

        if (score == 50){

          Debug.Log("Mataste los topos");
          audioSource.PlayOneShot(win);
          WonText.SetActive(true);
          
          GameManager.MoleGame = true;
          Invoke("Delay", 1.4f);

        }
    }

  public void Delay()
  {
    GameManager.ReturnToMainBool = true;
    SceneManager.LoadScene("Screen_Main");
  }

  public void Recargar(){
    SceneManager.LoadScene("Minigame2");
  }
    
  public void Missed(int moleIndex, bool isMole) {
    // Remove from active moles.
    currentMoles.Remove(moles[moleIndex]);
  }

}

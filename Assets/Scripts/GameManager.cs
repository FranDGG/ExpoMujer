using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  public static bool PipeGame, MoleGame, RiddleGame, BugsGame, QuizzGame, DressUpGame, PuzzleGame, FlowersGame, ReturnToMainBool = false, CorrectAnswer = false;
  
  public static float PlayerPoints = 0;
  
  void Start()
  {

  }

  void Update()
  {

  }

}

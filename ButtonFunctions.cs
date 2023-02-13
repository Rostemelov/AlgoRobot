using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
   public void loadHome()
   {SceneManager.LoadScene("OPEN");}
   public void loadGameMode()
   {SceneManager.LoadScene("GameModeSelect");}
   public void loadCredits()
   {SceneManager.LoadScene("Credits");}
   public void enterlvl1()
   {SceneManager.LoadScene("Basic Game 1");}
   public void enterlvl2()
   {SceneManager.LoadScene("Basic Game 2");}
   public void enterlvl3()
   {SceneManager.LoadScene("Basic Game 3");}
   public void exit()
   {Application.Quit();}
}

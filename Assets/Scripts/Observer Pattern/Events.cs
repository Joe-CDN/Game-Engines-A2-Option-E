using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObserverPattern
{
    //Events
    public abstract class PlayerEvents
    {
        public abstract void LoadWinScreen();
    }

    public class LoadWin : PlayerEvents
    {
        public override  void LoadWinScreen()
        {
            SceneManager.LoadScene("Win");
        }
    }
}

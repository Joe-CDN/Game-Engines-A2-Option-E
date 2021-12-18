using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class Observer 
    {
        public abstract void OnNotify();
    }

    public class End : Observer
    {
        //The observer gameobject which will do something
        GameObject Obj;
        //What will happen when this observer gets an event
        PlayerEvents playerEvent;

        public End(GameObject Obj, PlayerEvents playerEvent)
        {
            this.Obj = Obj;
            this.playerEvent = playerEvent;
        }

        //What the observer will do if the event fits it (will always fit but you will probably change that on your own)
        public override void OnNotify()
        {
            playerEvent.LoadWinScreen();
        }
    }
}

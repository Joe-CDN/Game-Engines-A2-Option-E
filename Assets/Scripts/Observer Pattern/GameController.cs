using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class GameController : MonoBehaviour
    {
        public GameObject player;
        //The boxes that will jump
        public GameObject endObj;

        //Will send notifications that something has happened to whoever is interested
        Subject subject = new Subject();

        // Start is called before the first frame update
        void Start()
        {
            End end1 = new End(endObj, new LoadWin());

            subject.AddObserver(end1);
        }

        // Update is called once per frame
        void Update()
        {
            if(Move.finished == true)
            {
                subject.Notify();
            }
        }
    }
}

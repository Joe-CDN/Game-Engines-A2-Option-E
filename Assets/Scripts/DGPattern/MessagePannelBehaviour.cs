using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class MessagePannelBehaviour : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI messageDisplay;
    [SerializeField] private float tweenTime;

    private Queue<string> messages = new Queue<string>();

    private void OnEnable()
    {
        NewBehaviourScript.fuelRunOut += NewBehaviourScript_FuelRunOut;
    }

    private void OnDisable()
    {
        NewBehaviourScript.fuelRunOut -= NewBehaviourScript_FuelRunOut;
    }

    // private void Awake() {
    //     messageDisplay.rectTransform.localScale = new Vector3(0, 0, 0);
    // }

    private void NewBehaviourScript_FuelRunOut(string obj)
    {
        messageDisplay.text = obj;
        // messageDisplay.rectTransform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        // messageDisplay.rectTransform.DOScale(0, tweenTime);

        // messages.Enqueue(obj);
        // Debug.Log("Current queue length: "+ messages.Count.ToString());
    }

    // private void Update() {
    //     CheckQueue();
    // }

    private void CheckQueue()
    {
        if (!DOTween.IsTweening(messageDisplay.rectTransform))
        {
            if (messages.Count > 0)
            {
                DisplayMessageAnimate(messages.Dequeue());
            }
        }
    }

    private void DisplayMessageAnimate(string obj)
    {
        messageDisplay.text = obj;
        messageDisplay.rectTransform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        messageDisplay.rectTransform.DOScale(0, tweenTime);
    }
}

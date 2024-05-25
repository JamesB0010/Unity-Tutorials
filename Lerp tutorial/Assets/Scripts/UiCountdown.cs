using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCountdown : MonoBehaviour
{
    private UnityEngine.UI.Text text;

    private bool countdownActive = false;

    private void Start()
    {
        this.text = GetComponent<UnityEngine.UI.Text>();
    }

    private void Update()
    {
        bool spaceBarReleased = Input.GetKeyUp(KeyCode.Space);
        if (spaceBarReleased && countdownActive == false)
        {
            //start countdown
            this.countdownActive = true;
            
            11.0f.LerpTo(0.0f, 10.0f,
                value =>
                {
                    text.text = ((int)value).ToString();
                },
                pkg =>
                {
                    this.countdownActive = false;
                    text.text = "Press Space to start Countdown";
                }
                );
        }
    }
}

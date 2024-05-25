using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LerpTest : MonoBehaviour
{
    private Vector3 targetPosition = new Vector3(10, 0, 20);

    private float timeToTake = 1.0f;
    private void Start()
    {
        transform.position.LerpTo(targetPosition, timeToTake,
            updatedPosition =>
            {
                transform.position = updatedPosition;
            },
            pkg =>
            {
                //reset the timing
                pkg.ResetTiming();
                
                //swap the start and target
                (pkg.start, pkg.target) = (pkg.target, pkg.start);
                
                //feed package back into global processor
                GlobalLerpProcessor.AddLerpPackage(pkg);
            });
    }
}

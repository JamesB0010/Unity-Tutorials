using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TypeLerpExtensions
{
    public static void LerpTo(this float value, float target, float timeToTake = 1.0f,
        LerpStep<float> updateCallback = null, PackageProcessed finishedCb = null, AnimationCurve animCurve = null)
    {
        updateCallback ??= (float val) => { Debug.Log(val);};

        finishedCb ??= pkg => { Debug.Log("Finished lerping"); };

        animCurve ??= GlobalLerpProcessor.linearCurve;
        
        GlobalLerpProcessor.AddLerpPackage(
            new FloatLerpPackage(
                value,
                target,
                updateCallback,
                finishedCb,
                timeToTake,
                animCurve
                )
            );
    }
    
    public static void LerpTo(this Vector3 value, Vector3 target, float timeToTake = 1.0f,
        LerpStep<Vector3> updateCallback = null, PackageProcessed finishedCb = null, AnimationCurve animCurve = null)
    {
        updateCallback ??= val => { Debug.Log(val);};

        finishedCb ??= pkg => { Debug.Log("Finished lerping"); };

        animCurve ??= GlobalLerpProcessor.linearCurve;
        
        GlobalLerpProcessor.AddLerpPackage(
            new Vector3LerpPackage(
                value,
                target,
                updateCallback,
                finishedCb,
                timeToTake,
                animCurve
            )
        );
    }
}

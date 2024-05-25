using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LerpStep<T>(T currentValue);

public delegate void PackageProcessed(LerpPackage pkg);

public abstract class LerpPackage
{
    public PackageProcessed finalCallback;
    public float timeToLerp;
    public float elapsedtime;
    public float currentPercentage;
    public AnimationCurve animCurve;
    
    public abstract object start { get; set; }
    public abstract object target { get; set; }

    public void ResetTiming()
    {
        this.elapsedtime = 0.0f;
    }

    protected LerpPackage(PackageProcessed finalCb, float timeToLerp, AnimationCurve animCurve)
    {
        this.finalCallback = finalCb;
        this.timeToLerp = timeToLerp;
        this.animCurve = animCurve;
        this.animCurve ??= GlobalLerpProcessor.linearCurve;
    }

    public abstract void AddToProcessor(ref LerpPackageProcessor processor);

    public abstract void RunStepCallback();
}
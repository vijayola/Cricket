using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_destroy_watcher : MonoBehaviour
{
    private Action OnBallDestroyed;

    public void Init(Action callback)
    {
        OnBallDestroyed = callback;
    }

    private void OnDestroy()
    {
        OnBallDestroyed?.Invoke();
    }
}

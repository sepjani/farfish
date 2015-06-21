using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AnimateObjects : MonoBehaviour 
{
    public Button.ButtonClickedEvent todo;
    public GameObject[] animationObjects;
    public AnimationClip[] customAnimations;

    public bool animateOnce = false;
    public bool animateNOW = false;
    private bool wasAnimated = false;

    protected Animation[] animComponents;
    protected string[] clipNames;

    int count;

    protected virtual void Awake()
    {
        if (animationObjects.Length == customAnimations.Length)
        {
            animComponents = new Animation[animationObjects.Length];
            clipNames = new string[animationObjects.Length];
        }
        else
        {
            Debug.LogError("GameObject: " + gameObject.name + ". AnimationObjects. Count of objects are not equal counf of animations!");
        }

        count = Mathf.Max(animationObjects.Length, customAnimations.Length);

        for (int index = 0; index < count; index++)
        {
            clipNames[index] = Convert.ToString(UnityEngine.Random.Range(long.MinValue, long.MaxValue));
            clipNames[index] += Time.time;
            if (animationObjects[index] == null)
            {
                Debug.LogError("GameObject: " + gameObject.name + " animationObjects[" + index + "] = null");
                continue;
            }
            clipNames[index] += animationObjects[index].name;

            animComponents[index] = animationObjects[index].GetComponent<Animation>();
            if (animComponents[index] == null)
                animComponents[index] = animationObjects[index].AddComponent<Animation>();

            if (customAnimations[index] == null)
            {
                Debug.LogError("GameObject: " + gameObject.name + " customAnimations[" + index + "] = null");
                continue;
            }
            animComponents[index].AddClip(customAnimations[index], clipNames[index]);
        }
    }

    void Update()
    {
        if (animateNOW)
        {
            Animate();
        }
    }

    public void Animate()
    {
        animateNOW = false;
        if (animateOnce && wasAnimated) return; wasAnimated = true;
        if (todo != null) todo.Invoke();
        for (int index = 0; index < count; index++)
        {
            if (animComponents[index] == null)
            {
                Debug.LogError("GameObject: " + gameObject.name + " animComponents[" + index + "] = null");
                continue;
            }
            animComponents[index].Stop();
            // animComponents[index].Stop(clipNames[index]);
            animComponents[index].Blend(clipNames[index]);
        }
    }
}

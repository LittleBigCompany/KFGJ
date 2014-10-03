using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Camera/Blur Manager")]
public class BlurManager : MonoBehaviour {

    [Range(0.0001f, 1.0f)]
    public float BlurInitialProbability = 0.3f;
    [Range(0.0001f, 0.05f)]
    public float BlurProbabilityIncreaseRate = 0.01f;
    public Timer TimerObject;
    [Range(0.00001f, 1.0f)]
    public float BlurLerpTime = 0.001f;
    public float BlurCooldown = 10.0f;

    private float blurProbability = 0.0f;
    private float timer = 0.0f;
    private float currentMinute = 0.0f;
    private float timeLeft = 0.0f;
    private Blur cameraBlur;
    private bool canRandom = true;
    private int blurIter;
    private int blurDownsample;
    private bool increaseBlurSize = false;
    private float lastBlurTime = 0.0f;
    private bool checkTime = true;

	// Use this for initialization
	void Start ()
    {
        blurProbability = BlurInitialProbability;
        currentMinute = TimerObject.TimeLeft;
        cameraBlur = this.GetComponent<Blur>();
        blurIter = cameraBlur.blurIterations;
        blurDownsample = cameraBlur.downsample;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if (canRandom)
        {
            float x = Random.Range(0.0f, 1000.0f);
            if (x / 1000.0f > (1.0f - blurProbability))
            {
                cameraBlur.blurIterations = blurIter;
                cameraBlur.downsample = blurDownsample;
                canRandom = false;
                increaseBlurSize = true;
            }
        }

        if(increaseBlurSize)
        {
            cameraBlur.blurSize = Mathf.Lerp(cameraBlur.blurSize, 10.0f, BlurLerpTime);
            if(cameraBlur.blurSize > 9.0f)
            {
                increaseBlurSize = false;
            }
        }
        else
        {
            cameraBlur.blurSize = Mathf.Lerp(cameraBlur.blurSize, 0.0f, BlurLerpTime);
            if(cameraBlur.blurSize < 0.5f)
            {
                cameraBlur.blurIterations = 1;
                cameraBlur.downsample = 0;
                if (!checkTime)
                {
                    lastBlurTime = timer;
                }
                checkTime = true;
            }
        }

        if(timer - lastBlurTime > BlurCooldown && checkTime)
        {
            canRandom = true;
            checkTime = false;
        }

        timeLeft = (currentMinute * 60.0f - timer) / 60.0f;
        if(timeLeft < currentMinute - 1.0f)
        {
            currentMinute -= 1.0f;
            blurProbability += BlurProbabilityIncreaseRate;
        }
	}
}

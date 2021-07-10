using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomRotation_script : MonoBehaviour
{
    public GameObject room;
    int rotationSpeed = 5;
    float RotationTimer;
    [SerializeField] bool isRotating = false;
    [SerializeField] bool isCounting = false;
    [SerializeField] float currentRotation;
    [SerializeField] int rotationDirection;
    Coroutine rotationCounterCoroutine;
    Coroutine rotateRoomCoroutine;
    public TMP_Text timer_text;
    public TMP_Text direction_text;

    void Start()
    {
        rotationDirection = Random.Range(0,2); //Gives a random number of 0 or 1. 0 will mean left and 1 will mean right
        currentRotation = this.transform.rotation.eulerAngles.z;
        RotationTimer = 10;
        isCounting = true;
        rotationCounterCoroutine = StartCoroutine(RotationCounter());
    }

    private void Update()
    {
        timer_text.text = "Rotate in: " + (int)RotationTimer;
        direction_text.text = DirectionDetermination();
        StartRotation();
        CheckRotation();
    }

    void StartRotation()
    {
        if (RotationTimer <= 0)
        {
            StopCoroutine(rotationCounterCoroutine);
            isCounting = false;
            RotationTimer = 10;
            rotateRoomCoroutine = StartCoroutine(RotateRoomCoroutine(CalculateRotation()));
        }
    }

    void CheckRotation()
    {
        if (!isRotating && !isCounting)
        {
            rotationDirection = Random.Range(0,2); //Gives a random number of 0 or 1. 0 will mean left and 1 will mean right
            currentRotation = Mathf.RoundToInt(this.transform.rotation.eulerAngles.z);
            rotationCounterCoroutine = StartCoroutine(RotationCounter());
        }
    }

    string DirectionDetermination()
    {
        if(rotationDirection == 0)
        {
            return "Left";
        } 
        else
        {
            return "Right";
        }
    }

    IEnumerator RotateRoomCoroutine(float angle)
    {
        isRotating = true;

        while (IsBetween(this.transform.rotation.eulerAngles.z, (float)(angle + 0.001), (float)(angle - 0.001)) == false)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
            Debug.Log(this.transform.rotation.eulerAngles.z);
            yield return null;
        }
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
        ResetIsRotating();
    }

    IEnumerator RotationCounter()
    {
        isCounting = true;
        while (RotationTimer > 0)
        {
            RotationTimer -= Time.deltaTime;
            yield return null;
        }
    }

    void ResetIsRotating()
    {
        isRotating = false;
        StopCoroutine(rotateRoomCoroutine);
    }

    float CalculateRotation()
    {
        if(rotationDirection == 0)
        {
            switch (currentRotation)
            {
                case 0:
                    return 270;
                    break;
                case 90:
                    return 0;
                    break;
                case 180:
                    return 90;
                    break;
                case 270:
                    return 180;
                    break;
            }
        }
        else if (rotationDirection == 1)
        {
            switch (currentRotation)
            {
                case 0:
                    return 90;
                    break;
                case 90:
                    return 180;
                    break;
                case 180:
                    return 270;
                    break;
                case 270:
                    return 0;
                    break;
            }
        }
        return 0;
    }

    bool IsBetween(float angle, float lowerBound, float upperBound)
    {
        if(lowerBound > upperBound)
        {
            return angle >= upperBound && angle <= lowerBound;
        }
        return angle >= lowerBound && angle <= upperBound;
    }
}

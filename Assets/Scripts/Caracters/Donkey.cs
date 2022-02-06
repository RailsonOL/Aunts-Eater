using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donkey : MonoBehaviour
{
    public float BoostTime = 5.0f;
    public float BoostForce = 3.0f;

    bool boost = false;

    private void Start()
    {
        if (PlayerPrefs.GetString("CurrentPlayer") == "P4")
        {
            BoostTime *= 2;

            Destroy(gameObject, BoostTime * 2);
        }
        else
        {
            Destroy(gameObject, BoostTime * 2);
        }
    }
    void Update()
    {
        transform.position += GameController.instance.SpawnVelocity * Time.deltaTime * Vector3.right;
    }

    void OnMouseDown()
    {
        BoostVelocity();
        Invoke(nameof(BoostVelocity), BoostTime);
    }

    public void BoostVelocity()
    {
        boost = !boost;
        if (boost)
        {
            GameController.instance.SpawnVelocity += -BoostForce;
        }
        else
        {
            GameController.instance.SpawnVelocity += +BoostForce;
        }
    }
}

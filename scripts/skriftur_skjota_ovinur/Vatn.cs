﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vatn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Debug.Log("Drukknaði");
            SceneManager.LoadScene(0);

        }
    }
}

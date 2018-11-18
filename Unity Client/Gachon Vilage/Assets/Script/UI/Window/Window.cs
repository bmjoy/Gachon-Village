﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public List<GameObject> Toggle;
    void Start()
    {
        if (Toggle.Count > 0)
        {
            Toggle[0].SetActive(true);
            for (int i = 1; i < Toggle.Count; i++)
            {
                Toggle[i].SetActive(false);
            }
        }
    }
    public void TabChange(string name)
    {
        for(int i = 0; i < Toggle.Count;i++)
        {
            if (Toggle[i].name == name) Toggle[i].SetActive(true);
            else Toggle[i].SetActive(false);
        }
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public bool isOpen()
    {
        return gameObject.activeSelf;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
}
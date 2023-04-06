using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    Monster[] _monsters;
    
    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
            GoToNextLevel();
    }

    void GoToNextLevel()
    {
        throw new NotImplementedException();
    }

    bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }


        return true;
    }
}

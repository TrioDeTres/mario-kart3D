using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public BonusManager bonusManager;
    public ShellManager shellManager;

    void Start()
    {
        bonusManager.OnShellGot += shellManager.CreateShells;
    }
}

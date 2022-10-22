using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : Actionable
{
    public override void Activate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public override void Deactivate()
    {

    }
}

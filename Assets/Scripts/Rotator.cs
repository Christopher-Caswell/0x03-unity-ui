using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Rotator is a script that will rotate a game object around an axis.
/// </summary>
public class Rotator : MonoBehaviour
{
    /// <summary>
    /// Rotata
    /// </summary>
    void Update()
    {
        transform.Rotate(Vector3.right * (45 * Time.deltaTime));
    }
}

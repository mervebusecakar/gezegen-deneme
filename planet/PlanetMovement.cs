using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public float orbitSpeed;
    public float orbitPeriod=0f;

    [Range(0f, 1f)]
    public float orbitProgress;
    public ellipse orbitPath;// = new ellipse();
    public bool orbitActive;

    public Transform movingPlanet;

    private void SetOrbitObject()
    {
        Vector2 orbit = orbitPath.Evaluate(orbitProgress);
        movingPlanet.position = new Vector3(orbit.x, 0f, orbit.y);

    }
    private void Start()
    {
        StartCoroutine(StartOrbiting());
    }

    private IEnumerator StartOrbiting()
    {
        yield return new WaitForSeconds(.5f);

        if (orbitPeriod < 0.1f)
            orbitPeriod = .1f;

        float speed = 1 / orbitPeriod;

        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * speed;
            orbitProgress %= 1;
            SetOrbitObject();
            yield return null;
        }
    }
}

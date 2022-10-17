using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour
{
    public List<GameObject> planets = new List<GameObject>();
    public GameObject star;

    public float sunRealSizeRU = 696340;

    public static float distance_UNITY_Ratio = Mathf.Pow(10, 4.9f);
    public static float model_UNITY_Ratio = 67911;

    private void Start()
    {
        Spawn_Star();
    }


    private void Spawn_Star()
    {
        var _copy = Instantiate(star, Vector3.zero, Quaternion.identity);
        float sun_unity_scale = sunRealSizeRU / model_UNITY_Ratio;
        _copy.transform.localScale = new Vector3(sun_unity_scale, sun_unity_scale, sun_unity_scale);
        Spawn_Planets();

    }
    private void Spawn_Planets()
    {
        foreach (var item in planets)
        {
            var _copy = Instantiate(item);

            planetScript _planetScript = _copy.GetComponentInChildren<planetScript>();
            float _size = _copy.GetComponentInChildren<planetScript>().planetSizeRU / model_UNITY_Ratio;

            _copy.transform.Find("Model").localScale = new Vector3(_size,_size,_size);


            _copy.GetComponent<PlanetMovement>().orbitPath = new ellipse((float)_planetScript.semiMajorAxisRU/
                distance_UNITY_Ratio,(float)_planetScript.semiMajorAxisRU/distance_UNITY_Ratio);
        }
    }
}

using UnityEngine;
using System.Collections;

public class SpecialEffectsHelper : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    public static SpecialEffectsHelper Instance;

    public Detonator explosion;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    /// <summary>
    /// Create an explosion at the given location
    /// </summary>
    /// <param name="position"></param>
    public void Explosion(Vector3 position)
    {
        instantiate(explosion, position);
    }

    /// <summary>
    /// Instantiate a Particle system from prefab
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    private Detonator instantiate(Detonator prefab, Vector3 position)
    {
        Detonator newDetonation = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as Detonator;


        return newDetonation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hittable objects
/// </summary>
public class ProjectileObstacle : MonoBehaviour {

    private enum ObjectMaterial { Metal, Wood, Explosive }
    [SerializeField]
    private ObjectMaterial objectMaterial;

    [SerializeField]
    private GameObject brokenWood;

    [SerializeField]
    private GameObject explosionParticleSystem;

    public void Hit(Vector3 hitDirection)
    {
        switch (objectMaterial)
        {
            case ObjectMaterial.Metal:
                print("you hit metal");
                break;
            case ObjectMaterial.Wood:
                GameObject brokenWoodInstance = Instantiate(brokenWood);
                brokenWood.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Destroy(gameObject);
                break;
            case ObjectMaterial.Explosive:
                GameObject explosionParticleSystemInstance = Instantiate(explosionParticleSystem);
                explosionParticleSystemInstance.transform.position = gameObject.transform.position;
                Destroy(gameObject);
                break;
        }
    }
}

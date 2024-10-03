using System.Collections.Generic;
using UnityEngine;

public class Exploader : MonoBehaviour
{
    public void Explode(List<Cube> cubes)
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            Rigidbody rigidBody = cubes[i].RigidBody;

            rigidBody.AddForce(Random.insideUnitCircle, ForceMode.Acceleration);
        }
    }

    public void ExplodeTerritory(Cube center)
    {
        float radius = 500;
        float power = 500;

        Vector3 explosionPosition = center.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Cube cube))
            {
                float scaleCoefficient= cube.transform.localScale.x;

                cube.RigidBody.AddExplosionForce(power / scaleCoefficient, explosionPosition, radius / scaleCoefficient);
            }
        }
    }
}
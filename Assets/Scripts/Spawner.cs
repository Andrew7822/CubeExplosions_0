using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Cube Spawn(Cube cube)
    {
        Cube newCube = Instantiate(cube);

        newCube.Reconstruct();

        return newCube;
    }
}
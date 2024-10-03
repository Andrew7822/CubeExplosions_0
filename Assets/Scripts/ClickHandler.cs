using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const int MinNumberÑubes = 2;
    private const int MaxNumberÑubes = 7;
    private const int RandomMax = 101;
    private const int RandomMin = 1;

    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploader _exploader;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                GameObject objectHit = hit.transform.gameObject;

                if (objectHit.TryGetComponent(out Cube cube))
                {
                    if (cube.FissionÑhance >= Random.Range(RandomMin, RandomMax))
                    {
                        int countCube = Random.Range(MinNumberÑubes, MaxNumberÑubes);

                        List<Cube> cubes = new(countCube);

                        for (int i = 0; i < countCube; i++)
                        {
                            cubes.Add(_spawner.Spawn(cube));
                        }

                        _exploader.Explode(cubes);
                    }
                    else 
                    {
                        _exploader.ExplodeTerritory(cube);
                    }

                    Destroy(objectHit);
                }
            }
        }
    }
}
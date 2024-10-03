using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
   [field: SerializeField] public int Fission—hance { get; private set; } = 100;

    public Rigidbody RigidBody { get; private set; }

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    public void Reconstruct()
    {
        int decreaseFactor = 2;

        transform.localScale /= decreaseFactor;  
        Fission—hance /= decreaseFactor;

        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
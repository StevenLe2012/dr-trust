using UnityEngine;
using UnityEngine.InputSystem;

public class ExampleSpawnCube : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private InputActionProperty inputAction;

    // private void Update()
    // {
    //     if (inputAction.action.WasPressedThisFrame())
    //     {
    //         GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
    //         Rigidbody cubeRigidbody = spawnedCube.GetComponent<Rigidbody>();
    //         cubeRigidbody.velocity = transform.forward * spawnSpeed;
    //     }
    // }
}

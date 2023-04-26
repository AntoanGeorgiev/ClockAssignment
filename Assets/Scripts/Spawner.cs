using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects;
    public UnityEvent InputEvent;
    bool a = false;
    [SerializeField] Material hourMaterial;
    [SerializeField] Material minutesMaterial;
    [SerializeField] Material secondsMaterial;
    void Start()
    {
        float b = UnityEngine.Random.Range(1f, 4f); // Bool for exercise 4
        if (numberOfObjects > 10) { numberOfObjects = 10; } //Set a limit on maximum number of clothes that can fit in a scene
        for (int i = 0; i < numberOfObjects; i++) // There is already one clock in the scene from exercise 1 so the real number of clocks is this +1
        {
            Vector3 randomPosition = new Vector3 (Random.Range(-9f,9f), Random.Range(-4f, 4f), 0f);
            Collider[] colliders = Physics.OverlapSphere(randomPosition, 1.5f);
            if (colliders.Length == 0) // By checking that the objects don't collide we make sure they don't superpose
            {
                Instantiate(prefab, randomPosition, Quaternion.identity);
            }
            else // We keep trying till we get a working scenario
            {
                i--;
            }
        }
        if (b >= 1f && b < 2f)  // Exercise 4 case
        {
            hourMaterial.color = Color.blue;
            minutesMaterial.color = Color.yellow;
            secondsMaterial.color = Color.red;
        }
        if (b >= 2f && b < 3f) // Exercise 4 case
        {
            hourMaterial.color = Color.cyan;
            minutesMaterial.color = Color.grey;
            secondsMaterial.color = Color.gray;
        }
        if (b >= 3f && b < 4f) // Exercise 4 case
        {
            hourMaterial.color = Color.black;
            minutesMaterial.color = Color.black;
            secondsMaterial.color = Color.black;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If we get space clicked, we trigger an input event
        {
            InputEvent.Invoke();
        }
    }

    public void AddAnotherClock() // The input event when clicking space
    {
        if (numberOfObjects < 10)
        {
            do
            {
                Vector3 randomPosition = new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 4f), 0f);
                Collider[] colliders = Physics.OverlapSphere(randomPosition, 1.5f);
                if (colliders.Length == 0)
                {
                    Instantiate(prefab, randomPosition, Quaternion.identity);
                    numberOfObjects++;
                    a = true;
                }
            }
            while (!a); // makes sure that we won't get empty space, if there is no validation at some cases there won't be a new clock because the pos will superpose
            a = false;
        }
        else Debug.Log("Too many clocks!"); //making sure the clocks aren't over the limit
    }
 }

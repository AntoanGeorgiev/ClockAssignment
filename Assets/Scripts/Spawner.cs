using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects;

    void Start()
    {
        if (numberOfObjects > 10) { numberOfObjects = 10; }
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3 (Random.Range(-9f,9f), Random.Range(-4f, 4f), 0f);
            Collider[] colliders = Physics.OverlapSphere(randomPosition, 1.5f);
            if (colliders.Length == 0)
            {
                Instantiate(prefab, randomPosition, Quaternion.identity);
            }
            else
            {
                i--;
            }
        }
    }
}

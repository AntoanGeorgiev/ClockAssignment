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
        float b = UnityEngine.Random.Range(1f, 4f);
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
        if (b >= 1f && b < 2f)
        {
            hourMaterial.color = Color.blue;
            minutesMaterial.color = Color.yellow;
            secondsMaterial.color = Color.red;
        }
        if (b >= 2f && b < 3f)
        {
            hourMaterial.color = Color.cyan;
            minutesMaterial.color = Color.grey;
            secondsMaterial.color = Color.gray;
        }
        if (b >= 3f && b < 4f)
        {
            hourMaterial.color = Color.black;
            minutesMaterial.color = Color.black;
            secondsMaterial.color = Color.black;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputEvent.Invoke();
        }
    }

    public void AddAnotherClock()
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
            while (!a);
            a = false;
        }
        else Debug.Log("Too many clocks!");
    }
 }

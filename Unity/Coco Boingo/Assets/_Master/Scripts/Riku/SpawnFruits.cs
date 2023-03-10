using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject fruitPrefab;
    public float timeBetweenSpawn = 1f;
    public float timeToSpawn = 2f;
    void Start()
    {

    }

    void Update()
    {
            if (Time.time >= timeToSpawn)
            {
                SpawnFruit();
                timeToSpawn = Time.time + timeBetweenSpawn;
            }
        
    }
    void SpawnFruit()
    {
        int randomList = Random.Range(0, spawnPoints.Length); //Obtenemos un numero aleatorio entre 0 y la cantidad de objetos en la lista

        for (int i = 0; i < spawnPoints.Length; i++) //Se ejecuta mientras i sea menor a la cantidad de objetos en la lista
        {
            if (randomList == i) //Si el numero aleatorio y el valor de i(osea el numero del ciclo en el que nos encontramos) son diferentes entre si, se realiza la funcion
            {
                GameObject fruit = ObjectPooling.instance.GetPooledObject();
                if (fruit != null)
                {
                    fruit.transform.position = spawnPoints[i].position;
                    fruit.SetActive(true);
                }
                //Instantiate(fruitPrefab, spawnPoints[i].position, Quaternion.identity); //Crea un objeto en la posicion del objeto asignado en la lista, dependiendo del valor de i
            }
        }
    }
}

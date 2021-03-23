using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject[] waypoints; //Pontos posicionados para servir de referência para o NPC
    int currentWp = 0; //Em qual ponto Npc está atualmente
    float speed = 1.0f; // velocidade do NPC
    float accuracy = 1.0f; //Distancia entre o NPC e o waypoint
    float rotSpeed = 0.4f; //Velocidade da rotação do NPC

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint"); //Procura os gameobjects com a Tag "Waypoint" na scene
    }

    void LateUpdate()
    {
        if (waypoints.Length == 0) return; //Se waypoints for igual a 0, da inicio as ações
        Vector3 lookAtGoal = new Vector3(waypoints[currentWp].transform.position.x, this.transform.position.y, waypoints[currentWp].transform.position.z); //Adicionando os pontos para o NPC seguir
        Vector3 direction = lookAtGoal - this.transform.position; this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime); // Adicionando a rotação para o NPC

        if(direction.magnitude < accuracy) //Caso a magnitude do direction for menor que a acuracia
        {
            currentWp++; //Passa para o proximo ponto
            if(currentWp >= waypoints.Length) //Se o currentWP ultrapassar o tamanho da array de Waypoints
            {
                currentWp = 0; //CurrentWP igual a 0
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime); //Adicionando velocidade ao NPC
    }
}

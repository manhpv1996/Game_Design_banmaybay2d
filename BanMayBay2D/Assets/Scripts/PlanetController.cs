using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
    public GameObject[] Planets;
    // queue to hold planets
    Queue<GameObject> availablePlanets = new Queue<GameObject>();
	// Use this for initialization
	void Start () {
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);
        // call the MovePlanetDown every 20 seconds
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update () {
		
	}
    void MovePlanetDown()
    {
        EnqueuePlanets();
        if (availablePlanets.Count == 0)
            return;
        // get planets from queue
        GameObject aPlanet = availablePlanets.Dequeue();
        //set the planet isMoving flag =true
        aPlanet.GetComponent<Planet>().isMoving = true;

    }
    // function to enqueue planet ar below the screen and not moving
    void EnqueuePlanets()
    {
        foreach(GameObject aPlanet in Planets)
        {
            // if the planet is below screen vaf tthe planet is not moving
            if((aPlanet.transform.position.y<0) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                //reset planet position
                aPlanet.GetComponent<Planet>().ResetPosition();
                //enqueue the planet
                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
}

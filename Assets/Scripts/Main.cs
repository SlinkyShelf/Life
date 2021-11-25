using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [Header("Simulation")]
    public int OrganismCount = 100;
    public int StepCount = 500;
    public int Generations = 500;
    public int StepTime = 1/60;
    public Vector2 Area = new Vector2(50, 50);

    [Header("Food")]
    public int FoodCount = 50;
    public float FoodSize = .5f;

    [Header("Organisms")]
    public float RotationSpeed = 1;
    public float MoveSpeed = 1;
    public int VisionRayCount = 5;
    public float VisionRaySpread = (Mathf.PI*2) * (45/360);
    public float VisionRayLength = 3;

    [Header("Neural Network")]
    public int HiddenLayerNodes = 2;
    public int HiddenLayers = 2;
    public int InputCount = 5;
    public int OutputCount = 2;

    [Header("Visuals")]
    public GameObject OrganismModel;
    public GameObject FoodModel;

    struct Organism 
    {
        NNBase nn;
        Vector2 position;
        float rotation;
        GameObject model;
    }

    struct Food
    {

    }

    const float UnitCircle = Mathf.PI*2;

    private Organism[] Organisms;
    private Food[] FoodArray;

    void generateFood()
    {
        for (int i = 0; i < FoodCount; i++)
        {
            Vector2 position = new Vector2(
                
            );
        }
    }

    void newGeneration()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Organisms = new Organism[OrganismCount];

        //Spawning Food
        Food = new Vector2[FoodCount];

        for (int i = 0; i < FoodCount; i++)
        {
            Organisms[i] = new Organism();
            GameObject FoodModelClone =  GameObject.Instantiate(FoodModel, new Vector3);
            FoodModelClone.transform.parent = gameObject.transform;
            Organisms[i].Model = FoodModelClone;
        }

        generateFood()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

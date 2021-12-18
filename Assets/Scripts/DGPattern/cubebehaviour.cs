using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private static List<NewBehaviourScript> allCubes= new List<NewBehaviourScript>();
    [SerializeField] private float thrust;
    [SerializeField] private float massNoFuel;
    [SerializeField] private float initialMass;
    [SerializeField] private float burnTime;
    [SerializeField] private string cubeName;

    private Rigidbody rb;
    private Transform tr;
    private float currentMass;
    private float massBurnRate;
    private float currentThrust;
    private float lastMass;

    public static int NumberOfCubes => allCubes.Count;

    public static event System.Action<string> fuelRunOut;

    public static bool DestryRandomRocket()
    {
        if (allCubes.Count == 0) return false;
        Destroy(allCubes[Random.Range(0, allCubes.Count)].gameObject);
        return true;
    }

    private void OnEnable()
    {
        allCubes.Add(this);
    }

    private void OnDisable()
    {
        allCubes.Remove(this);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        tr = transform;
    }

    private void Start()
    {
        currentMass = initialMass;
        massBurnRate = (initialMass - massNoFuel) / burnTime;
        rb.mass = initialMass;
        currentThrust = thrust;
    }

    private void UpdateMass(float dt)
    {
        if (currentMass <= massNoFuel) return;

        lastMass = currentMass;
        currentMass -= massBurnRate * dt;

        if ((lastMass > massNoFuel) && (currentMass <= massNoFuel))
        {
            Debug.Log(cubeName + "has run out of fuel!");
            fuelRunOut?.Invoke(cubeName + "has run out of fuel!");
        }

        rb.mass = Mathf.Max(currentMass, massNoFuel);
    }

    private void UpdateThrust()
    {
        if (currentMass <= massNoFuel) currentThrust = 0;
    }

    private void ApplyThrust()
    {
        rb.AddForce(currentThrust * tr.up);
    }

    private void FixedUpdate()
    {
        UpdateMass(Time.fixedDeltaTime);
        UpdateThrust();
        ApplyThrust();
    }
}

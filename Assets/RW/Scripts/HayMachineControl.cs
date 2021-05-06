using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachineControl : MonoBehaviour
{
    //we can see the value by adding a public variable
    public float inputKeyValue = 0f;
    public float speed_modifier = 35.0f;
    public float movementBoundaries = 21.5f;
    public Transform haySpawnpoint;

    public GameObject hayShootObject;
    public float thresholdShoot = 0.5f;
    public float measureTime = 0.0f;

    public Transform modelParent;

    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        measureTime = Time.time;

        LoadModel();
    }

    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject);

        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputKeyValue = Input.GetAxis("Horizontal");

        //we can also check the value output by using the console
        //Debug.Log("value" + inputKeyValue);

        Vector3 movement = Vector3.right * speed_modifier * Time.deltaTime * inputKeyValue;
        Vector3 final_movement = transform.position + movement;

        if (final_movement.x < movementBoundaries && final_movement.x > -movementBoundaries)
            transform.Translate(movement);

        ///////////////
        //// Shooting Hay

        ShootHay();
    }

    void ShootHay() { 
        if (Input.GetKey(KeyCode.Space) && (Time.time - measureTime > thresholdShoot))
        {
            SoundManager.Instance.PlayShootClip();

            Vector3 hayPosition = new Vector3(haySpawnpoint.position.x, 1.0f, haySpawnpoint.position.z);
            Instantiate(hayShootObject, hayPosition, Quaternion.identity);
            measureTime = Time.time;
        }
    }
}

using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class ZombieRLAgent : Agent
{
    public Transform player;
    public float moveSpeed = 3.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 🔧 Physics stability fixes
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // extra stability (IMPORTANT for blinking fix)
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public override void OnEpisodeBegin()
    {
        // ✅ world-space reset with safe height
        transform.position = new Vector3(
            Random.Range(-4f, 4f),
            0.5f,
            Random.Range(-4f, 4f)
        );

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // ✅ FIXED: consistent WORLD SPACE ONLY
        sensor.AddObservation(transform.position);
        sensor.AddObservation(player.position);

        // helps RL stability
        sensor.AddObservation(rb.linearVelocity);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float x = actions.ContinuousActions[0];
        float z = actions.ContinuousActions[1];

        Vector3 move = new Vector3(x, 0f, z);

        // smooth movement (removes grid/square behavior)
        move = Vector3.ClampMagnitude(move, 1f);

        Vector3 velocity = move * moveSpeed;

        // preserve physics Y
        velocity.y = rb.linearVelocity.y;

        rb.linearVelocity = velocity;

        // 🔥 reward shaping (prevents center convergence bug)
        float distance = Vector3.Distance(transform.position, player.position);
        AddReward(-distance * 0.0015f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddReward(10f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var a = actionsOut.ContinuousActions;
        a[0] = Input.GetAxis("Horizontal");
        a[1] = Input.GetAxis("Vertical");
    }
}
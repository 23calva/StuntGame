using UnityEngine;

namespace Burnout
{
    public class Vehicle : MonoBehaviour
    {
        public WheelCollider[] wheels;

        public Rigidbody body;
        public Vector3 input;

        private void Update()
        {
            input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            for(int i = 0; i < wheels.Length + 1; i++)
            {
                if (i <= 1)
                {
                    wheels[i].steerAngle += input.x;
                    wheels[i].steerAngle = Mathf.Clamp(wheels[i].steerAngle, -135, 135);
                }
                else if (i <= 3)
                {
                    wheels[i].motorTorque += input.z;
                }
            }
        }

        /*
        public Wheel[] wheels = new Wheel[4];

        public Rigidbody body;
        public Vector3 input;

        [SerializeField]
        public Spring spring;

        public int wheelCount;
        public GameObject wheelPrefab;
        public float wheelRadius;

        private void Start()
        {
            for (int i = 0; i < wheelCount; i++)
            {
                if(i < 2) { wheels[i].isSteerable = true; }
                wheels[i].Init(this);
            }
        }

        private void FixedUpdate()
        {
            // Gravity
            //body.velocity = new Vector3(body.velocity.x, Mathf.Clamp(body.velocity.y, -54f, 54f), body.velocity.z);

            foreach(var obj in wheels)
            {
                obj.wishVelocity += new Vector3(input.z * 5, 0, input.x);

                obj.FixedUpdate();

                obj.wishVelocity -= new Vector3(input.z * 5, 0, input.x);
            }
        }

        private void Update()
        {
            input = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

            foreach(var obj in wheels) { obj.Update(); }
        }

        private void OnValidate()
        {
            foreach(var obj in wheels) { obj.UpdateValues(); }
        }

        private void OnDrawGizmos()
        {
            foreach(var obj in wheels)
            {
                float iterations = 10;
                float degrees = 135;

                degrees = Mathf.Clamp(degrees, 0, 360); // Arcs/Circles are limited to 0-360 degrees.

                float angleDiff = (degrees / iterations); // Degrees between each raycast.
                float angleCurr = (angleDiff / 2);

                float offset = (angleDiff * (iterations / 2)) + (180 - degrees);

                for(uint i = 0; i < iterations; i++)
                {
                    float c = i / iterations;
                    if     (c < 0.25f) { Gizmos.color = new Color(1, 0, 0, 1); }
                    else if(c < 0.50f) { Gizmos.color = new Color(0, 1, 0, 1); }
                    else if(c < 0.75f) { Gizmos.color = new Color(0, 0, 1, 1); }
                    else if(c < 1.00f) { Gizmos.color = new Color(1, 1, 1, 1); }

                    Quaternion dir = Quaternion.AngleAxis(angleCurr + offset, transform.right);

                    Vector3 start = obj.transform.position + (transform.up * obj.spring.offset);

                    Gizmos.DrawRay(start, dir * transform.up * (wheelRadius + 0.1f));

                    angleCurr += angleDiff;
                }

                Gizmos.color = Color.magenta;
                Gizmos.DrawWireSphere(obj.transform.position + new Vector3(0f, spring.maxRange + wheelRadius, 0f), 0.1f);
                Gizmos.DrawWireSphere(obj.transform.position - new Vector3(0f, spring.minRange + wheelRadius, 0f), 0.1f);

                Gizmos.color = Color.gray;
                Gizmos.DrawLine(obj.transform.position + new Vector3(0f, spring.maxRange, 0f), obj.transform.position - new Vector3(0f, spring.minRange, 0f));
            }
        }
        */
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
 /*   [RequireComponent(typeof(ThirdPersonCharacter))]*/

    public class EnemySight : MonoBehaviour
    {
        public NavMeshAgent agent;
        /*public ThirdPersonCharacter character;*/
        public int attackDamage = 20;

        public enum State
        {
            PATROL,
            CHASE,
            INVESTIGATE,
        }

        public State state;
        private bool alive;

        // variables for ptrolling
        public GameObject[] waypoints;
        private int waypointInd;
        public float patrolSpeed = 0.5f;

        // variables for chasing
        public float chaseSpeed = 1f;
        public GameObject target;

        // variables for investigating
        public Vector3 investigateSpot;
        public float timer = 0f;
        public float investigateWait = 0f;

        // variables for sight
        public float heightMultiplier;
        public float sightDist = 10;


        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            /*character = GetComponent<ThirdPersonCharacter>();*/

            agent.updatePosition = true;
            agent.updateRotation = false;

            waypoints = GameObject.FindGameObjectsWithTag("WayPoint");
            waypointInd = Random.Range(0, waypoints.Length);

            state = EnemySight.State.PATROL;

            alive = true;

            heightMultiplier = 1.36f;

            // Start FSM
            StartCoroutine(FSM());
        }

        IEnumerator FSM()
        {
            while (alive)
            {
                switch (state)
                {
                    case State.PATROL:
                        Patrol();
                        break;
                    case State.CHASE:
                        Chase();
                        break;
                    case State.INVESTIGATE:
                        Investigate();
                        break;
                }
                yield return null;
            }
        }

        void Patrol()
        {
            agent.speed = patrolSpeed;

            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                /*character.Move(agent.desiredVelocity, false, false);*/
            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                waypointInd = Random.Range(0, waypoints.Length);
            }
            else
            {
                /*character.Move(Vector3.zero, false, false);*/
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            }
        }

        void Chase()
        {
            /*PlayerHealth.Instance.TakeDamage(20);*/

            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);
            /*character.Move(agent.desiredVelocity, false, false);*/
        }

        void Investigate()
        {
            timer += Time.deltaTime;

            agent.SetDestination(this.transform.position);
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            /*character.Move(Vector3.zero, false, false);*/
            transform.LookAt(investigateSpot);

            if(timer >= investigateWait)
            {
                state = EnemySight.State.PATROL;
                timer = 0;
            }

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                state = EnemySight.State.INVESTIGATE;
                investigateSpot = other.gameObject.transform.position;
            }
        }

        void FixedUpdate()
        {
            RaycastHit hit;

            Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
            Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.green);
            Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);

            if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    state = EnemySight.State.CHASE;
                    target = hit.collider.gameObject;
                    target.GetComponent<PlayerInventory>().DamageTaken(attackDamage);
                }
            }

            if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    state = EnemySight.State.CHASE;
                    target = hit.collider.gameObject;
                    target.GetComponent<PlayerInventory>().DamageTaken(attackDamage);
                }
            }

            if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    state = EnemySight.State.CHASE;
                    target = hit.collider.gameObject;
                    target.GetComponent<PlayerInventory>().DamageTaken(attackDamage);
                }
            }
        }
    }
}

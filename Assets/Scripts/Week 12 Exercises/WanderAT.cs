using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

        public BBParameter<Transform> targetPositionBBP;
        //public BBParameter<float> timeSinceLastSampleBBP;
        //public BBParameter<bool> isMovingBBP;

        public BBParameter <float> wanderRate;
        public BBParameter <float> wanderRadius;
        private float randX;
        private float randZ;

        //private NavMeshAgent navAgent;
        //private Vector3 lastTargetDestination;

        protected override string OnInit() {
            //navAgent = agent.GetComponent<NavMeshAgent>();
            //if (navAgent == null)
                //return $"{agent.name} - NavigationTask: Unable to get NavMesh Agent reference";
            //else
                return null;
        }

		protected override void OnExecute() {
            randX = Random.Range(-wanderRadius.value, wanderRadius.value);
            randZ = Random.Range(-wanderRadius.value, wanderRadius.value);
            Vector3 destination = new Vector3();
            destination.x = randX;
            destination.y = agent.transform.position.y;
            destination.z = randZ;
            targetPositionBBP.value.transform.position = destination;
            Debug.Log("I didn't do anything~");
            EndAction(true);
            //timeSinceLastSampleBBP.value = 5;
        }

		protected override void OnUpdate()
        {
            //timeSinceLastSampleBBP.value += Time.deltaTime;
            //if (timeSinceLastSampleBBP.value > wanderRate.value)
            //{
            //    timeSinceLastSampleBBP.value = 0;

            //    randX = Random.Range(-wanderRadius.value, wanderRadius.value);
            //    randZ = Random.Range(-wanderRadius.value, wanderRadius.value);
            //    Vector3 destination = new Vector3();
            //    destination.x = randX;
            //    destination.y = agent.transform.position.y;
            //    destination.z = randZ;

            //    //navAgent.SetDestination(destination);
            //    targetPositionBBP.value = destination;
            //    //EndAction(true);

            //}
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}
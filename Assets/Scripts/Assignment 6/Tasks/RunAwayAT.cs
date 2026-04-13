using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class RunAwayAT : ActionTask
    {
        public BBParameter<Transform> hostileTargetBBP;

        public float safeRadius;

		private NavMeshAgent navAgent;

        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
            float distance = Vector3.Distance(agent.transform.position, hostileTargetBBP.value.position);
            if (distance < safeRadius)
            {
                Vector3 safeDirection = (agent.transform.position - hostileTargetBBP.value.position).normalized;
                Vector3 desiredPoint = agent.transform.position + safeDirection * safeRadius;

                navAgent.SetDestination(desiredPoint);
            }
			else if(distance > safeRadius)
			{
                EndAction(true);
            }
            
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
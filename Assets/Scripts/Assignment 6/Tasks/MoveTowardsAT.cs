using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class MoveTowardsAT : ActionTask {

		NavMeshAgent navAgent;
		public BBParameter<Vector3> targetBBP;

		protected override string OnInit()
		{
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute()
		{
			navAgent.SetDestination(targetBBP.value);
			//agent.settarget
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{

		}

	}
}
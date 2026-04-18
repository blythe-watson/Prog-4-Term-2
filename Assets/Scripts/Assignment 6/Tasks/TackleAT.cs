using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TackleAT : ActionTask
	{
		public BBParameter<GameObject> targetBBP;
		Rigidbody targetRigidbody;

		Vector3 forceDirection;

		protected override string OnInit()
		{
			targetRigidbody = targetBBP.value.GetComponent<Rigidbody>();
			return null;
		}

		protected override void OnExecute()
		{
			forceDirection = (targetBBP.value.transform.position - agent.transform.position).normalized;
			targetRigidbody.AddForce(forceDirection, ForceMode.Impulse);
			Debug.Log("GOTCHA!");
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			
		}

	}
}
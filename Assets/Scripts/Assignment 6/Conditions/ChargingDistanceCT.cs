using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ChargingDistanceCT : ConditionTask {

		public BBParameter<float> chargeDistanceBBP;
		public LayerMask targetLayer;

		//public float distanceToTarget;

		//Called whenever the condition gets enabled.
		protected override void OnEnable()
		{
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{
            Collider[] targets = Physics.OverlapSphere(agent.transform.position, chargeDistanceBBP.value, targetLayer);
			//Debug.Log(targets.Length);
			if (targets.Length > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
                
		}
	}
}
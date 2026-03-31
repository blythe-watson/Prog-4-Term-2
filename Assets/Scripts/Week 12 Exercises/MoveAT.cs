using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveAT : ActionTask
	{
		public BBParameter<Vector3> moveDirectionBBP;
		public BBParameter<float> moveSpeedBBP;
		public BBParameter<float> turnSpeedBBP;

		protected override void OnUpdate()
		{
			Vector3 planar = new Vector3(moveDirectionBBP.value.x, 0f, moveDirectionBBP.value.z);
			Quaternion desiredRotation = Quaternion.LookRotation(planar);

			agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, desiredRotation, turnSpeedBBP.value * Time.deltaTime);
			agent.transform.position += moveSpeedBBP.value * Time.deltaTime * agent.transform.forward;

			moveDirectionBBP.value = Vector3.zero;
		}
	}
}
using NodeCanvas.Framework;
using UnityEngine;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions
{

	public class SeekAT : ActionTask
	{
		public BBParameter<Transform> seekTargetBBP;
		public BBParameter<Vector3> moveDirectionBBP;

		[MinValue(0.00f)] public float weight;
		
		protected override void OnUpdate()
		{
			moveDirectionBBP.value += (seekTargetBBP.value.position - agent.transform.position).normalized * weight;
		}
	}
}
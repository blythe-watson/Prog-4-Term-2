using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatSproutAT : ActionTask
	{
		public BBParameter<Transform> sproutTargetBBP;

		protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
			SproutManager sproutScript = sproutTargetBBP.value.GetComponentInParent<SproutManager>();
			sproutScript.planted = false;
			Debug.Log("munch munch munch yum yum yum");

			EndAction(true);
		}

		protected override void OnUpdate()
		{
			
		}

	}
}
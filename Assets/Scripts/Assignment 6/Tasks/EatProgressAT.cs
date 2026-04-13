using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;



namespace NodeCanvas.Tasks.Actions {

	public class EatProgressAT : ActionTask
	{
		public BBParameter<Slider> eatingSliderBBP;
		public BBParameter<float> eatingTimeBBP;
		public float eatingProgress;
		public float eatingSpeed = 0.3f;
		
		protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
            eatingProgress += Time.deltaTime * eatingSpeed;
			eatingSliderBBP.value.value = eatingProgress/eatingTimeBBP.value;

			if (eatingProgress >= eatingTimeBBP.value)
			{
				eatingSliderBBP.value.value = 0;
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
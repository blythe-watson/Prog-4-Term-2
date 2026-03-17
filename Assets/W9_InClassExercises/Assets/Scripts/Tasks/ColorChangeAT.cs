using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class ColorChangeAT : ActionTask
    {
        public BBParameter<Renderer> rendererBBP;
        public Color color = Color.white;
        [Tooltip("If true, ignores color property.")] public bool randomColor = false;

        protected override void OnExecute()
        {
            if (randomColor)
                rendererBBP.value.material.color = new(Random.value, Random.value, Random.value, 1f);
            else
                rendererBBP.value.material.color = color;
            EndAction(true);
        }
    }
}
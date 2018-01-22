//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Emerald AI")]
	[Tooltip("Damages an AI according to the DamageAmount parameter. ")]
	public class EAI_Damage : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Emerald_AI))] 
		public FsmOwnerDefault gameObject;
		
		public FsmInt damageAmount;
		
		public Emerald_AI.TargetType typeOfTarget;

		public FsmBool everyFrame;

		Emerald_AI theScript;
  

		public override void Reset()
		{
			gameObject = null;
			damageAmount = null;
			typeOfTarget =  Emerald_AI.TargetType.AI;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<Emerald_AI>();


			if (!everyFrame.Value)
			{
				DoTheMagic();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMagic();
			}
		}

		void DoTheMagic()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			theScript.Damage(damageAmount.Value, typeOfTarget);            
		}

	}
}
//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Emerald AI")]
	[Tooltip(" ")]
	public class EAI_PH_DamagePlayer : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayerHealth))] 
		public FsmOwnerDefault gameObject;
		
		public FsmFloat damageTaken;

		public FsmBool everyFrame;

		PlayerHealth theScript;
  

		public override void Reset()
		{
			gameObject = null;
			damageTaken = null;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<PlayerHealth>();


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

			theScript.DamagePlayer(damageTaken.Value);            
		}

	}
}
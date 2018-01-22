//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Emerald AI")]
	[Tooltip("Sets the current target to the Target parameter. ")]
	public class EAI_SetTarget : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Emerald_AI))] 
		public FsmOwnerDefault gameObject;
		
		public FsmGameObject target;

		public FsmBool everyFrame;

		Emerald_AI theScript;
  

		public override void Reset()
		{
			gameObject = null;
			target = null;
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

			theScript.SetTarget(target.Value.transform);            
		}

	}
}
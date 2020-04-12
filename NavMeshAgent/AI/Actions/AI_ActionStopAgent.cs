using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode.FSMG;
using XNode.FSMG.Components;

[CreateAssetMenu(menuName = "FSMG/AI/NavMeshAgent/Actions/AgentStop")]
public class AI_ActionStopAgent : AI_ActionBase
{
    public override void Execute(FSMBehaviour fsm)
    {
        NavMeshAgentFSM fsmn = (NavMeshAgentFSM)fsm;

        fsmn.navMeshAgent.isStopped = true;
        fsmn.navMeshAgent.ResetPath();
        fsmn.navMeshAgent.velocity = Vector3.zero;

        if (fsmn.rigidBody.isKinematic == false)
            fsmn.rigidBody.velocity = Vector3.zero;
    }
}

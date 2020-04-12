using XNode.FSMG.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using UnityEngine.AI;

namespace XNode.FSMG
{
    [CreateNodeMenu("NavMeshAgent/Decisions/IsFinishPath")]
    public class Node_Decision_FinishPath : NodeBase_Decision
    {

        [Output(typeConstraint = TypeConstraint.Strict)]
        public NodeBase_Decision outDecision;



        public override bool Execute(FSMBehaviour fsm)
        {
            if (Application.isEditor && Application.isPlaying == false)
                return false;

            return CheckDecision((NavMeshAgentFSM)fsm);
        }

        private bool CheckDecision(NavMeshAgentFSM fsm)
        {
            NavMeshAgent agent = fsm.navMeshAgent;

            if (agent.remainingDistance <= agent.stoppingDistance + fsm.agentStats.agent.pathEndThreshold)
            {
                if (agent.pathPending == false)
                {
                    //agent.isStopped = true;
                    return true;
                }
            }

            return false;
        }

    }
}
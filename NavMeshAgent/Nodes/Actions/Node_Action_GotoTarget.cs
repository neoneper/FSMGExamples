using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using XNode;
using XNode.FSMG.Components;

namespace XNode.FSMG
{
    [CreateNodeMenu("NavMeshAgent/Actions/GoToTarget")]
    public class Node_Action_GotoTarget : NodeBase_Action
    {

        private FSMTargetBehaviour go = null;
        private FSMTargetBehaviour TargetGo
        {
            get
            {
                if (go == null)
                {
                    go = GetInputValue<FSMTargetBehaviour>("inputTarget", this.inputTarget);
                }

                return go;
            }
        }
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Strict, backingValue = ShowBackingValue.Never)]
        public FSMTargetBehaviour inputTarget;

        [Output]
        public NodeBase_Action outAction = null;

        public override void Execute(FSMBehaviour fsm)
        {
            DoExecute((NavMeshAgentFSM)fsm);
        }
        private void DoExecute(NavMeshAgentFSM fsm)
        {
            if (Application.isEditor && Application.isPlaying == false)
                return;


            NavMeshAgent agent = fsm.navMeshAgent;
            FSMTargetBehaviour target = TargetGo;
            AIAgentStats agentStats = fsm.agentStats;

            if (TargetGo == null)
            {
                agent.ResetPath();
                agent.isStopped = true;
                return;
            }


            Transform chase = null;
            chase = target.transform;

            agent.destination = chase.position;
            agent.isStopped = false;

            if (agent.remainingDistance <= agent.stoppingDistance + agentStats.agent.pathEndThreshold)
            {
                if (agent.pathPending == false)
                {
                    // agent.ResetPath();
                    agent.isStopped = true;
                }
            }
        }


    }
}
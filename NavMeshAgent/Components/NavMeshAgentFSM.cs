using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace XNode.FSMG.Components
{
    [AddComponentMenu("FSM/NavMeshAgentController")]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    public class NavMeshAgentFSM : FSMBehaviour
    {

        private NavMeshAgent _navMeshAgent = null;
        private Rigidbody _rigidbody = null;

        [SerializeField]
        private AIAgentStats _agentStats = null;

        public AIAgentStats agentStats { get { return _agentStats; } }
        public NavMeshAgent navMeshAgent
        {
            get
            {

                if (_navMeshAgent == null)
                    _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
                if (_navMeshAgent == null)
                    _navMeshAgent = gameObject.AddComponent<NavMeshAgent>();

                return _navMeshAgent;


            }
        }
        public Rigidbody rigidBody
        {
            get
            {
                if (_rigidbody == null)
                    _rigidbody = GetComponent<Rigidbody>();

                return _rigidbody;
            }
        }
       
        private void Start()
        {
            if (graph != null)
            {
                graph.InitGraph(this);
                navMeshAgent.enabled = true;
                isReady = true;
            }
        }
        private void Update()
        {
            if (!isReady) return;
            graph.UpdateGraph(this);
        }



    }
}
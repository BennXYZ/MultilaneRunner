using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorEvents : StateMachineBehaviour {

    enum States { Enter, Update, Exit};

    [SerializeField]
    States state;

    [SerializeField]
    int eventNumber;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (state == States.Enter)
            animator.gameObject.GetComponent<eventsByAnimator>().DoEvent(eventNumber);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (state == States.Update)
            animator.gameObject.GetComponent<eventsByAnimator>().DoEvent(eventNumber);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (state == States.Exit)
            animator.gameObject.GetComponent<eventsByAnimator>().DoEvent(eventNumber);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}

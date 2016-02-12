using UnityEngine;
using System.Collections;
using EnemyClasses;

public class EnemyAttack : StateMachineBehaviour {
	static public bool idle;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//yield return WaitForSeconds(3f);


		animator.SetInteger("attack",Random.Range(0,4)); // determines what attack enemy will use, fire, water, earth, air
		idle = true; //puts enemy in idle state where he is about to attack
		animator.SetBool("idle", idle); //sets actual value in abimator

	}

	private IEnumerator wait(float seconds){
		yield return new WaitForSeconds(seconds); //used to make the ui wait
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(animator.GetInteger("canAttack") == 0){
			wait (1.0f);
			animator.gameObject.GetComponent<Enemy>().toggle_attack();
		}
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

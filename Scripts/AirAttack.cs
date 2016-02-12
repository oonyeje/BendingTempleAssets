using UnityEngine;
using System.Collections;
using EnemyClasses;

public class AirAttack : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(animator.gameObject.GetComponent<Enemy>().indexPos == 0){
			if(animator.GetInteger("attack") == 0){
				GameObject AirBend = (GameObject)Instantiate(Resources.Load("AirBend", typeof(GameObject)), GameObject.Find("skillSpawn(1)").transform.position, GameObject.Find("skillSpawn(1)").transform.rotation);
				AirBend.GetComponent<Rigidbody>().velocity = AirBend.transform.TransformDirection(Vector3.forward * 15);
				AirBend.transform.FindChild("source").gameObject.tag = "Enemy1Attack";
			}
		}
		
		if(animator.gameObject.GetComponent<Enemy>().indexPos == 1){
			if(animator.GetInteger("attack") == 0){
				GameObject AirBend = (GameObject)Instantiate(Resources.Load("AirBend", typeof(GameObject)), GameObject.Find("skillSpawn(2)").transform.position, GameObject.Find("skillSpawn(2)").transform.rotation);
				AirBend.GetComponent<Rigidbody>().velocity = AirBend.transform.TransformDirection(Vector3.forward * 15);
				AirBend.transform.FindChild("source").gameObject.tag = "Enemy2Attack";
			}
		}
		
		if(animator.gameObject.GetComponent<Enemy>().indexPos == 2){
			if(animator.GetInteger("attack") == 0){
				GameObject AirBend = (GameObject)Instantiate(Resources.Load("AirBend", typeof(GameObject)), GameObject.Find("skillSpawn(3)").transform.position, GameObject.Find("skillSpawn(3)").transform.rotation);
				AirBend.GetComponent<Rigidbody>().velocity = AirBend.transform.TransformDirection(Vector3.forward * 15);
				AirBend.transform.FindChild("source").gameObject.tag = "Enemy3Attack";
			}
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetInteger("attack",4);
		animator.SetBool("idle",false);
		animator.SetInteger("canAttack", 0);
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

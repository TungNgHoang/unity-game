using UnityEngine;

public class PlayOneShotBehavior : StateMachineBehaviour
{
    public AudioClip soundToPlay;
    public float volume = 1f;
    public bool playOnEnter = true, playOnExit = false, playAfterDelay = false;

    //Delay sound timer
    public float playDelay = 0.25f;
    private float timeSinceEntered = 0f;
    private float timeSinceExited = 0f;
    private bool hasDelaySoundPlayed = false;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnEnter)
        {
            AudioSource.PlayClipAtPoint(soundToPlay, animator.transform.position, volume);
        }

        timeSinceEntered = 0f;
        hasDelaySoundPlayed = false;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playAfterDelay && !hasDelaySoundPlayed)
        {
            timeSinceEntered += Time.deltaTime;
            if (timeSinceEntered >= playDelay)
            {
                AudioSource.PlayClipAtPoint(soundToPlay, animator.transform.position, volume);
                hasDelaySoundPlayed = true;
            }
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnExit)
        {
            AudioSource.PlayClipAtPoint(soundToPlay, animator.transform.position, volume);
        }
    }
}

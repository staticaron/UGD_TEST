using UnityEngine;

public class Player : PlayerController
{
    //Inherits from the player controller ands its functionality

    [SerializeField] ParticleSystem dustParticle;

    protected override void Dusting()
    {
        if (base.groundCheckRealtime == true && base.oldGroundCheckRealtime == false)
        {
            dustParticle.Play();
        }
    }

    public void StopMovement()
    {
        base.runEnabled = false;
        base.jumpEnabled = false;
        base.dashEnabled = false;
        base.grabEnabled = false;
        base.climbEnabled = false;
    }
}

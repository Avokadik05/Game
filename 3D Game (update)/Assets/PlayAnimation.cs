using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayAnimation : MonoBehaviour
{
    public Rig mob_rig;
    public float _weightSpeed = 3;

    public int attack_ID;
    
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R)) attack_ID = 1;
        else if(Input.GetKeyDown(KeyCode.T)) attack_ID = 2;*/

        if(attack_ID == 1)
        {
            mob_rig.weight = Mathf.MoveTowards(mob_rig.weight, 1, _weightSpeed * Time.deltaTime);
            if (mob_rig.weight == 1) attack_ID = 0;
        }
        else if(attack_ID == 2)
        {
            mob_rig.weight = Mathf.MoveTowards(mob_rig.weight, 0, _weightSpeed * Time.deltaTime);
            if (mob_rig.weight == 0) attack_ID = 0;
        }
    }
}

using System;
using System.Collections;
using Player;
using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
      [SerializeField] protected float range;
      [SerializeField] protected int damage;
      [SerializeField] protected Camera cam;
      [SerializeField] protected Animator toolAnimator;
      [SerializeField] private float cooldownTime;
      [SerializeField] private GameObject toolGameObject;

      protected bool _canAttack=true;
      protected IEnumerator _cooldownRoutine=null;
      protected PlayerInputAct _playerInputAct;
      protected static readonly int Attack1 = Animator.StringToHash("Attack");

      public virtual void Awake()
       {
           _playerInputAct = new PlayerInputAct();
           _playerInputAct.Player.Shoot.performed +=ctx=> Attack();
       }
       
       public virtual void Attack()
       {
           var transform1 = cam.transform;
           if (!Physics.Raycast(transform1.position, transform1.forward, out var hit, range) ) return;
           print(hit.transform.name);
           if (hit.transform.GetComponent<SpawnCubes>()&&_canAttack)
           {
               hit.transform.GetComponent<SpawnCubes>();
           }
           if (_cooldownRoutine == null&&_canAttack)
           {
               toolAnimator.SetTrigger(Attack1);
               if(_cooldownRoutine==null){
                   _cooldownRoutine = Cooldown();
                   StartCoroutine(_cooldownRoutine);
               }
           }
       }
       public IEnumerator Cooldown()
       {
           _canAttack = false;
           yield return new WaitForSeconds(cooldownTime);
           _canAttack = true;
           _cooldownRoutine = null;
       }

       public void ActivateTool()
       {
           toolGameObject.SetActive(true);
       }

       public void DeactivateTool()
       {
           toolGameObject.SetActive(false);
       }
       private void OnEnable()
       {
           _playerInputAct.Enable();
       }
    
       private void OnDisable()
       {
           _playerInputAct.Disable();
       }
}
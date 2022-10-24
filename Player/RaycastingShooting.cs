using System.Collections;
using UnityEngine;

namespace Player
{
    public class RaycastingShooting : Attackable
    {
        [SerializeField] private GameObject shootParticle, bloodParticle;
        [SerializeField] private Transform particlePos;
        [SerializeField] private int ammo=30;
        [SerializeField] private AudioSource scarShoot, scarReload;
        
        private IEnumerator _reloadRoutine=null;
        private PlayerInputAct _playerInputAct;
        private static readonly int Reload1 = Animator.StringToHash("Reload");

        private void Awake()
        {
            _playerInputAct = new PlayerInputAct();
            _playerInputAct.Player.Shoot.started += ctx => Attack();
            _playerInputAct.Player.Reload.started += ctx => ReloadRoutine();
            print(_playerInputAct.Player.Shoot.enabled);
  
        }

        public override void Attack()
        {
            print("Shoot");
            var transform1 = cam.transform;
            if(Physics.Raycast(transform1.position, transform1.forward, out var hit, range))
            {
                if (hit.transform.GetComponent<SpawnCubes>() && _canAttack && ammo > 0)
                {
                    hit.transform.GetComponent<SpawnCubes>();
                    Instantiate(bloodParticle, hit.point, hit.transform.rotation);
                }
            }
            if (_cooldownRoutine == null&&_canAttack&&ammo>0)
            {
                scarShoot.PlayOneShot(scarShoot.clip);
                ammo--;
                Instantiate(shootParticle, particlePos.position,particlePos.rotation);
                toolAnimator.SetTrigger(Attack1);
                if(_cooldownRoutine==null){
                    _cooldownRoutine = Cooldown();
                    StartCoroutine(_cooldownRoutine);
                }
            }
        }

        private void ReloadRoutine()
        {
            if(_reloadRoutine==null&&ammo<30){
                _reloadRoutine = Reload();
                StartCoroutine(_reloadRoutine);
                toolAnimator.SetTrigger(Reload1);
            }
        }
        private IEnumerator Reload()
        {
            scarReload.Play();
            _canAttack = false;
            yield return new WaitForSeconds(2);
            _canAttack = true;
            _reloadRoutine = null;
            ammo = 30;
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
}
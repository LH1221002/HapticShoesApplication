using UnityEngine;
using System.Collections;

namespace Footsteps
{

    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class FootstepTrigger : MonoBehaviour
    {

        Collider thisCollider;
        CharacterFootsteps footsteps;

        void Start()
        {
            thisCollider = GetComponent<Collider>();
            footsteps = GetComponentInParent<CharacterFootsteps>();
            Rigidbody thisRigidbody = GetComponent<Rigidbody>();

            if (thisCollider)
            {
                thisCollider.isTrigger = true;
                SetCollisions();
            }

            if (thisRigidbody) thisRigidbody.isKinematic = true;

            string errorMessage = "";

            if (!footsteps) errorMessage = "No 'CharacterFootsteps' script found as a parent, this footstep trigger will not work";
            else if (!thisCollider) errorMessage = "Please attach a collider marked as a trigger to this gameobject, this footstep trigger will not work";
            else if (!thisRigidbody) errorMessage = "Please attach a rigidbody to this gameobject, this footstep trigger will not work";

            if (errorMessage != "")
            {
                Debug.LogError(errorMessage);
                enabled = false;

                return;
            }
        }

        void OnEnable()
        {
            SetCollisions();
        }

        public class BoolObject
        {
            public bool b { get; set; }
        }
        public GameObject vibration;
        private BoolObject current;
        private float waitTime = 0.5f;

        void OnTriggerEnter(Collider other)
        {
            if (footsteps)
            {
                if (vibration)
                {
                    vibration.SetActive(true);
                    if(current!=null) current.b = true;
                    current = new BoolObject();
                    StartCoroutine(OnTriggeExitAfterTime(current));
                }
                //StartCoroutine(Vibration());
                footsteps.TryPlayFootstep();
            }
        }

        IEnumerator OnTriggeExitAfterTime(BoolObject stop)
        {
            for (int i = 0; i < 10; i++)
            {
                if (stop.b)
                {
                    yield break;
                }
                yield return new WaitForSeconds(waitTime / 10f);
            }
            vibration.SetActive(false);
        }

        private void OnTriggerExit(Collider other)
        {
            if (vibration)
            {
                vibration.SetActive(false);
            }
        }


        IEnumerator Vibration()
        {
            if (!vibration) yield break;
            Animator animator = vibration.GetComponent<Animator>();
            vibration.SetActive(true);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            vibration.SetActive(false);
        }

        void SetCollisions()
        {
            if (!footsteps) return;

            Collider[] allColliders = footsteps.GetComponentsInChildren<Collider>();

            foreach (var collider in allColliders)
            {
                if (collider != GetComponent<Collider>())
                {
                    Physics.IgnoreCollision(thisCollider, collider);
                }
            }
        }
    }
}

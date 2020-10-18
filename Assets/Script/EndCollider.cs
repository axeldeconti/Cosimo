using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCollider : MonoBehaviour
{
    [SerializeField] private GameObject _mongAvecHat = null;
    [SerializeField] private GameObject _mongSansHat = null;
    [SerializeField] private Transform _parent = null;

    public UnityEngine.Events.UnityEvent onGO = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove move = collision.transform.parent.GetComponent<PlayerMove>();

        if (move)
        {
            if (move.AsHat)
            {
                Transform t = Instantiate(_mongAvecHat, _parent.position, Quaternion.identity, _parent).transform;
                t.localPosition = Vector3.zero;
            }
            else
            {
                Transform t = Instantiate(_mongSansHat, _parent.position, Quaternion.identity, _parent).transform;
                t.localPosition = Vector3.zero;
            }

            move.DiseableMove();
            move.gameObject.SetActive(false);

            TextManager.instance.SetCollectible();
            LevelManager.instance.ChangeLevel();
            //onGO.Invoke();
        }
    }
}

using UnityEngine;

namespace _Root.Code.Input
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Transform WeaponPosition { get; private set; }
        [field: SerializeField] public Transform WeaponRotation { get; private set; }
        [field: SerializeField] public RangeDrawer RangeDrawer { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }

        public PlayerModel PlayerModel { get; private set; }


        public void InitializeView(PlayerModel playerModel)
        {
            PlayerModel = playerModel;
        }
    }
}
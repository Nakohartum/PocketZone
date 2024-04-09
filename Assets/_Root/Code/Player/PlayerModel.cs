namespace _Root.Code.Input
{
    public class PlayerModel
    {
        private Health.Health _health;
        public WeaponSo Weapon;
        public float Speed;
        

        public PlayerModel(WeaponSo weapon, float speed, Health.Health health)
        {
            Weapon = weapon;
            Speed = speed;
            _health = health;
        }
    }
}
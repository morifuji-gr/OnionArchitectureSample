namespace onion.Domain
{
    public class SaveData
    {
        public string Name {
            get;
        }
        public int Power {
            get;
        }
        public int Speed {
            get;
        }
        public int Health {
            get;
        }

        public SaveData(string name, int power, int speed, int health)
        {
            this.Name   = name;
            this.Power  = power;
            this.Speed  = speed;
            this.Health = health;
        }
    }
}

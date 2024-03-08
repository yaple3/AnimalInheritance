namespace AnimalInheritance
{
    // base Class 
    class Animal
    {
        private string name; // only accessible within this class
        protected string type; //accessible from derived classes
        public string color;  // accessible from any class

        public void setName(string name)
        {
            this.name = name;
        }
        public virtual string getName()
        {
            return this.name;
        }
        public void setType(string type) // for any class besides derived class will need get/set methods
        {
            this.type = type;
        }
        public virtual string getType()
        {
            return this.type;
        }
    }

    //Enumeration for habitat
    public enum Habitat
    {
        Freshwater,
        Saltwater,
        Both
    }

    // derived class
    class Fish : Animal
    {
        public string diet;  // accessible from any class
        protected bool _edible;  //accessible from derived classes
        private bool _regulated;  // only accessible within this class
        public Habitat habitat; // accessible from any class

        public void setEdible(bool edible)
        {
            _edible = edible;
        }

        public virtual bool getEdible()
        {
            return _edible;
        }

        public void setRegulated(bool regulated)
        {
            _regulated = regulated;
        }

        public virtual bool getRegulated()
        {
            return _regulated;
        }

        // access name through base because it is private
        public override string getName()
        {
            return base.getName();
        }

        // access type directly because it is protected and this is a derived class
        public override string getType()
        {
            return type;
        }

        public string GetHabitat()
        {
            switch (habitat)
            {
                case Habitat.Freshwater:
                    return "in freshwater";
                case Habitat.Saltwater:
                    return "in saltwater";
                case Habitat.Both:
                    return "in both freshwater & saltwater";
                default:
                    return "unknown";
            }
        }

        public void PrintFishFacts()
        {
            bool isEdible = true;
            string edibilityText;
            bool isRegulated = true;
            string regulationStatus;

            if (isEdible)
            {
                edibilityText = "I am an edible fish.";
            }
            else
            {
                edibilityText = "I am not edible.";
            }

            if (isRegulated)
            {
                regulationStatus = "I am a regulated fish.";
            }
            else
            {
                regulationStatus = "I am an unregulated fish.";
            }

            string habitatText = GetHabitat();

            Console.WriteLine($"I am a {type} fish and my name is {getName()}.");
            Console.WriteLine($"I am {color} and {diet}");
            Console.WriteLine(edibilityText);
            Console.WriteLine(regulationStatus);
            Console.WriteLine($"My habitat is {habitatText}.");

            switch (diet)
            {
                case "Carnivore":
                    Console.WriteLine("I am a fierce predator, hunting smaller fish and crustaceans.");
                    break;
                case "Herbivore":
                    Console.WriteLine("I like to munch on tasty plants and algae, which helps to keep the underwater ecosystem balanced.");
                    break;
                case "Omnivore":
                    Console.WriteLine("I enjoy a varied diet of both plants and animals.");
                    break;
                case "Filter feeder":
                    Console.WriteLine("I filter tiny food particles from the water. My diet plays a crucial role in maintaining water quality.");
                    break;
                default:
                    Console.WriteLine("my diet is unknown.");
                    break;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //object of the base class Animal
            Animal vermin = new Animal();
            vermin.setName("Mickey");
            vermin.setType("mouse");
            vermin.color = "black";
            Console.WriteLine("Animal object: Vermin information:");
            Console.WriteLine($"My name is {vermin.getName()}");
            Console.WriteLine($"I am a {vermin.getType()}");
            Console.WriteLine($"I am the color of {vermin.color}.");
            Console.WriteLine();

            // object of the derived class Fish
            Fish fishy = new Fish();
            fishy.setName("Nemo");
            fishy.setType("clownfish");
            // color is a public field and can be accessed anywhere
            fishy.color = "orange";
            fishy.diet = "Omnivore";
            fishy.setEdible(true);
            fishy.setRegulated(true);
            fishy.habitat = Habitat.Saltwater;
            Console.WriteLine("Animal object: Fish information:");
            fishy.PrintFishFacts();

            Console.ReadLine(); // pauses end of program display

        }
    }
}
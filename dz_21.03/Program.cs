using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_21._03
{
    public interface IAnimal
    {
        bool Live { get; set; }
    }
    public abstract class Herb : IAnimal
    {
        public bool Live { get; set; }
        public double Weight { get; set; }
        public abstract double EatGrass();
        public abstract string ToString();
    }
    public class Wild : Herb
    {
        public Wild()
        {
            Live = true;
            Weight = 0;
        }
        public Wild(double weight)
        {
            Weight = weight;
            Live = true;
        }
        public override double EatGrass()
        {
            if (Weight < 0)
            {
                Live = false;
                return Weight;
            }
            return Weight += 10;
        }

        public override string ToString()
        {
            return $"Beest Live - {Live}    Weight - {Weight}";
        }
    }
    public class Bison : Herb
    {
        public Bison()
        {
            Live = true;
            Weight = 0;
        }
        public Bison(double weight)
        {
            Weight = weight;
            Live = true;
        }
        public override double EatGrass()
        {
            if (Weight < 0)
            {
                Live = false;
                return Weight;
            }
            return Weight += 10;
        }
        public override string ToString()
        {
            return $"Bison Live - {Live}    Weight - {Weight}";
        }
    }
    public abstract class Predators : IAnimal
    {
        public bool Live { get; set; }
        public double Power { get; set; }
        public abstract double Eat(Herb herbivores);
        public abstract string ToString();
    }
    public class Lion : Predators
    {
        public Lion()
        {
            Live = true;
            Power = 0;
        }
        public Lion(double power)
        {
            Power = power;
            Live = true;
        }
        public override double Eat(Herb herbivores)
        {
            if (Power < 0)
            {
                Live = false;
                return Power;
            }
            if (Power > herbivores.Weight)
            {
                herbivores.Live = false;
                return Power += 10;
            }
            if (Power == herbivores.Weight)
            {
                return Power;
            }
            return Power -= 10;
        }
        public override string ToString()
        {
            return $"Lion Live - {Live}    Weight - {Power}";
        }
    }
    public class Wolf : Predators
    {
        public Wolf()
        {
            Live = true;
            Power = 0;
        }
        public Wolf(double power)
        {
            Power = power;
            Live = true;
        }
        public override double Eat(Herb herbs)
        {
            if (Power < 0)
            {
                Live = false;
                return Power;
            }
            if (Power > herbs.Weight)
            {
                herbs.Live = false;
                return Power += 10;
            }
            if (Power == herbs.Weight)
            {
                return Power;
            }
            return Power -= 10;
        }
        public override string ToString()
        {
            return $"Wolf Live - {Live}    Weight - {Power}";
        }
    }
    public abstract class Country
    {
        public List<Herb> list_herb { get; set; }
        public List<Predators> list_predators { get; set; }
        public abstract void CreationHerb(Herb herbivores);
        public abstract void CreationPredators(Predators predators);
    }
    public class Africa : Country
    {
        public Africa()
        {
            list_herb = new List<Herb>();
            list_predators = new List<Predators>();
        }
        public override void CreationHerb(Herb herbivores)
        {
            list_herb.Add(herbivores);
        }
        public override void CreationPredators(Predators predators)
        {
            list_predators.Add(predators);
        }
    }
    public class NorthAmerica : Country
    {
        public override void CreationHerb(Herb herbivores)
        {
            list_herb.Add(herbivores);
        }
        public override void CreationPredators(Predators predators)
        {
            list_predators.Add(predators);
        }
    }
    public class AnimalWorld
    {
        public void ShowAnimalHerbivores(Country country)
        {
            for (int i = 0; i < country.list_herb.Count; i++)
                Console.WriteLine(country.list_herb[i].ToString());
        }
        public void ShowAnimalPredators(Country country)
        {
            for (int i = 0; i < country.list_predators.Count; i++)
                Console.WriteLine(country.list_predators[i].ToString());
        }
        public void MealsHerbivores(Country country)
        {
            for (int i = 0; i < country.list_herb.Count; i++)
                country.list_herb[i].EatGrass();
        }
        public void NutritionCarnivores(Country country)
        {
            int j = 0;
            for (int i = 0; i < country.list_predators.Count || j < country.list_herb.Count; i++, j++)
                country.list_predators[i].Eat(country.list_herb[j]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Africa africa = new Africa();
            Wolf wolf = new Wolf(70);
            Lion lion = new Lion(100);
            africa.CreationPredators(wolf);
            africa.CreationPredators(lion);
            AnimalWorld world = new AnimalWorld();
            world.ShowAnimalHerbivores(africa);
            world.ShowAnimalPredators(africa);
            world.NutritionCarnivores(africa);
            world.ShowAnimalHerbivores(africa);
            world.ShowAnimalPredators(africa);
        }
    }
}

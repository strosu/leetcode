namespace _3._6.AnimalShelter;
class Program
{
    static void Main(string[] args)
    {
        var shelter = new AnimalShelter();
        shelter.Enqueue(new Cat());
        shelter.Enqueue(new Dog());
        shelter.Enqueue(new Dog());
        shelter.Enqueue(new Dog());
        shelter.Enqueue(new Cat());
        shelter.Enqueue(new Cat());

        Console.WriteLine(shelter.Get().ArrivalOrder);

        Console.ReadLine();
    }

    public class AnimalShelter
    {
        private int _counter = 0;

        private LinkedList<BaseAnimal> _dogQueue = new LinkedList<BaseAnimal>();
        private LinkedList<BaseAnimal> _catQueue = new LinkedList<BaseAnimal>();

        public void Enqueue(BaseAnimal animal)
        {
            _counter++;
            animal.ArrivalOrder = _counter;

            if (animal is Dog)
            {
                _dogQueue.AddLast(animal);
            }
            if (animal is Cat)
            {
                _catQueue.AddLast(animal);
            }
        }

        public BaseAnimal GetDog()
        {
            return GetLast(_dogQueue);
        }

        public BaseAnimal GetCat()
        {
            return GetLast(_catQueue);
        }

        public BaseAnimal Get()
        {
            if (_dogQueue.Count == 0)
            {
                return GetCat();
            }

            if (_catQueue.Count == 0)
            {
                return GetDog();
            }

            if (_catQueue.First().ArrivalOrder < _dogQueue.First().ArrivalOrder)
            {
                return GetCat();
            }

            return GetDog();
        }

        private BaseAnimal GetLast(LinkedList<BaseAnimal> queue)
        {
            if (queue.Count == 0)
            {
                throw new ArgumentException();
            }

            var animal = queue.Last;
            queue.RemoveLast();

            return animal.Value;
        }
    }

    public abstract class BaseAnimal
    {
        public int ArrivalOrder;
    }

    public class Dog : BaseAnimal { }

    public class Cat : BaseAnimal { }
}


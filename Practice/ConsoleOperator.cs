namespace Practice
{
    internal class ConsoleOperator
    {
        private readonly List<Person> _persons = new List<Person>();
        public void PeformCalculation()
        {
            Calculator calculator  = new Calculator();
            Console.WriteLine("Enter Number 1: ");
            int.TryParse(Console.ReadLine(), out int firstNumber);
            Console.WriteLine("Enter Number 2: ");
            int.TryParse(Console.ReadLine(), out int secondNumber);
            if (!Validator(firstNumber, secondNumber))
            {
                Console.WriteLine("Entered data is not valid!");
                return;
            }
            Console.WriteLine($"Addition Result: {calculator.Add(firstNumber,secondNumber)}");
            Console.WriteLine($"Subtraction Result: {calculator.Subtract(firstNumber,secondNumber)}");
            Console.WriteLine($"Multiplication Result: {calculator.Multiple(firstNumber,secondNumber)}");
            Console.WriteLine($"Division Result: {calculator.Divide(firstNumber,secondNumber)}");


        }
        public bool Validator(int firstNumber, int secondNumber)
        {
            if (firstNumber <= 0 || secondNumber <= 0)
            {
                return false;
            }
            return true;
        }

        internal void DisplayUserData()
        {
            this.PopulatePerson();
            var data = this._persons.Where(person => person.Age > 15);
            Console.WriteLine("\nPerson Datas");
            foreach(Person person in data)
            {
                Console.WriteLine($"Person Name: {person.Name} Age: {person.Age}");
            }
        }

        internal void PopulatePerson()
        {
            this._persons.Add(new Person("Arun", 20));
            this._persons.Add(new Person("Ajay", 45));
            this._persons.Add(new Person("Rajesh", 36));
            this._persons.Add(new Person("Vinoth", 10));
            this._persons.Add(new Person("Peter", 27));
            this._persons.Add(new Person("Parker", 33));
        }
    }
}

using Scaffold_VS.Model;

namespace Scaffold_VS.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            //...
            return person;
        }

        public void Delete(long id)
        {
            //...
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; ++i)
            {
                Person person = MockPerson((long)i);
                persons.Add(person);
            }

            return persons;
        }

        private Person MockPerson(long i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "person name " + i,
                LastName = "person lastname " + i,
                Address = "some addr " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return MockPerson(id);
        }

        public Person Update(Person person)
        {
            //...
            return person;
        }
    }
}

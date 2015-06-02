namespace _2_000_Things_You_Should_Know_About_CSharp_UnitTest
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static int PersonCount { get; set; }

        public Person()
        {

        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Description()
        {
            return string.Format("{0} is {1} yrs old.", this.Name, this.Age);
        }

        public static string DoGeneralPersonStuff()
        {
            return string.Format("{0} people.", PersonCount);
        }
    }
}
# Depth First Seach (DFS)
> Depth-first search (DFS) is an algorithm for traversing or searching tree or graph data structures. One starts at the root (selecting some arbitrary node as the root in the case of a graph) and explores as far as possible along each branch before backtracking.

Depth First Search (DFS) algorithm traverses a graph in a depthward motion and uses a stack to remember to get the next vertex to start a search, when a dead end occurs in any iteration.

Depth-first Search (DFS) is an algorithm for searching a graph or tree data structure. The algorithm starts at the root (top) node of a tree and goes as far as it can down a given branch (path), and then backtracks until it finds an unexplored path, and then explores it.

``` csharp
class DepthFirstSeach
    {
        public class Employee
        {
            public Employee(string name)
            {
                this.name = name;
            }
 
            public string name { get; set; }
            public List<Employee> Employees
            {
                get
                {
                    return EmployeesList;
                }
            }
 
            public void isEmployeeOf(Employee e)
            {
                EmployeesList.Add(e);
            }
 
            List<Employee> EmployeesList = new List<Employee>();
 
            public override string ToString()
            {
                return name;
            }
        }
 
        public class DepthFirstAlgorithm
        {
            public Employee BuildEmployeeGraph()
            {
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");
                Eva.isEmployeeOf(Sophia);
                Eva.isEmployeeOf(Brian);
 
                Employee Lisa = new Employee("Lisa");
                Employee Tina = new Employee("Tina");
                Employee John = new Employee("John");
                Employee Mike = new Employee("Mike");
                Sophia.isEmployeeOf(Lisa);
                Sophia.isEmployeeOf(John);
                Brian.isEmployeeOf(Tina);
                Brian.isEmployeeOf(Mike);
 
                return Eva;
            }
 
            public Employee Search(Employee root, string nameToSearchFor)
            {
                if (nameToSearchFor == root.name)
                    return root;
 
                Employee personFound = null;
                for (int i = 0; i < root.Employees.Count; i++)
                {
                    personFound = Search(root.Employees[i], nameToSearchFor);
                    if (personFound != null)
                        break;
                }
                return personFound;
            }
 
            public void Traverse(Employee root)
            {
                Console.WriteLine(root.name);
                for (int i = 0; i < root.Employees.Count; i++)
                {
                    Traverse(root.Employees[i]);
                }
            }
        }
 
        static void Main(string[] args)
        {
            DepthFirstAlgorithm b = new DepthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);
 
            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
        }
    }
```

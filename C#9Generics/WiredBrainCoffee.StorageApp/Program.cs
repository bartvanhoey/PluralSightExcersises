using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;


// ItemAdded<Employee> EmployeeAdded = EmployeeAdded;

// var itemAddedOrganization = new ItemAdded<Organization>(OrganizationAdded);

void OrganizationAdded(Organization organization)
{
    System.Console.WriteLine($"Organization added: {organization?.Name}");

};

// void EmployeeAdded(Employee employee)
// {
//     System.Console.WriteLine($"Employee added: {employee?.FirstName}");
// }

// Employees
var employeesRepo = new SqlRepository<Employee>(new StorageAppDbContext());
employeesRepo.ItemAdded+= EmployeeRepositoryItemAdded;

void EmployeeRepositoryItemAdded(object? sender, Employee employee)
{
        System.Console.WriteLine($"Employee added: {employee?.FirstName}");
}

AddEmployees(employeesRepo);
// IWriteRepository<Manager> mangersWriteRepo = new SqlRepository<Employee>(new StorageAppDbContext());
AddManagers(employeesRepo);
GetEmployeeById(employeesRepo);
IReadRepository<IEntity> employeeReadRepo = new SqlRepository<Employee>(new StorageAppDbContext());
WriteAllToConsole(employeeReadRepo);

Console.WriteLine();



// Organizations
var organizationRepository = new ListRepository<Organization>(OrganizationAdded);
AddOrganizations(organizationRepository);
organizationRepository.Save();
WriteAllToConsole(organizationRepository);



void GetEmployeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine($"Employee with id 2: {employee?.FirstName}");
}

static void WriteAllToConsole(IReadRepository<IEntity> repo)
{
    Console.WriteLine("================================");
    var items = repo.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("================================");
}

static void AddOrganizations(IRepository<Organization> organizationRepo)
{
    var organizations = new[] { new Organization { Name = "Pluralsight" }, new Organization { Name = "Google" } };
    organizationRepo.AddBatch<Organization>(organizations);
}

static void AddEmployees(IRepository<Employee> employeesRepo)
{
    var employees = new[]{
        new Employee { FirstName = "John" },
        new Employee { FirstName = "John" },
        new Employee { FirstName = "Anna" },
        new Employee { FirstName = "Thomas" }
    };

    employeesRepo.AddBatch<Employee>(employees);
}

void AddManagers(IWriteRepository<Manager> managersRepo)
{
    var sarahManager = new Manager { FirstName = "Sarah" };

    var sarahManagerCopy = sarahManager.Copy();
    managersRepo.Add(sarahManager);

    if (sarahManagerCopy is not null)
    {
        sarahManagerCopy.FirstName += "_copy";
        managersRepo.Add(sarahManagerCopy);

    }




    managersRepo.Add(new Manager { FirstName = "Henry" });
    managersRepo.Save();
}
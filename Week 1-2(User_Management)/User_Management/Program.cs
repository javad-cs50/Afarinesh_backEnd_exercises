
using System.Threading.Channels;
using User_Management;

var users = new List<User>();

var selectedNumber = 0;
uint id = 1;
while (true)
{
    Console.Clear();

    Console.WriteLine("====== User Management Menu ======");
    Console.WriteLine(" 0. Exit");
    Console.WriteLine(" 1. Show all users");
    Console.WriteLine(" 2. Add a new user");
    Console.WriteLine(" 3. Edit user by Id");
    Console.WriteLine(" 4. Delete user by Id");
    Console.Write(" Select an option: ");
    selectedNumber = int.Parse(Console.ReadLine());

    switch (selectedNumber)
    {
        case 0: return;

        //Show the list of users
        case 1:
            if (users.Count == 0)
                Console.WriteLine(" list is Empty!");
            else
                ShowUsers();
            break;

        //Add a user to the list of users
        case 2:
            AddUser();break;


        //update a user with id
        case 3: UpdateUser(); break;

        //delete a user with id
        case 4: DeleteUser(); break;
    }
}

void ShowUsers()
{
    Console.WriteLine(value: "=========================List of the Users=======================");
    foreach (var user in users)
    {
        Console.WriteLine(value: $"id: {user.Id} |  name : {user.FullName}  | age : {user.Age}");
    }
    Console.ReadKey();
    Console.Clear();
}
void AddUser()
{
    Console.WriteLine(" Enter your information :  ");
    Console.WriteLine("     Enter your name : ");
    var tempName = Console.ReadLine();
    Console.WriteLine("     Enter your age : ");

    var tempAge = uint.Parse(Console.ReadLine());

    Console.WriteLine($" your name is : {tempName} | your Age is : {tempAge}\n Are you sure?(y/n)");
    var acceptToAdd = Console.ReadLine().ToLower();
    if (acceptToAdd == "y")
    {

        users.Add(new User { Id = id, FullName = $"{tempName}", Age = tempAge });
        id++;
        Console.WriteLine(" succesfully Added.");
    }
    else
    {
        Console.WriteLine(" the user didn't add!");
    }
    Console.ReadKey();
    Console.Clear();
}
void UpdateUser()
{
    Console.WriteLine("Enter the user id : ");
    var tempId = uint.Parse(Console.ReadLine());
    var userForEdit = users.FirstOrDefault(n => n.Id == tempId);

    if (userForEdit != null)
    {
        Console.Write($"Enter new name (current: {userForEdit.FullName}): ");
        var newName = Console.ReadLine();
        Console.Write($"Enter new age (current: {userForEdit.Age}): ");
        var newAge = uint.Parse(Console.ReadLine());
        userForEdit.FullName = newName;
        userForEdit.Age = newAge;
        Console.WriteLine(" succesfully updated.");

    }
    else
        Console.WriteLine(" didn't find a user with this Id");

    Console.ReadKey();
    Console.Clear();
}
void DeleteUser()
{
    Console.WriteLine(" Enter the user id : ");
    var tempId = uint.Parse(Console.ReadLine());
    var userForEdit = users.FirstOrDefault(n => n.Id == tempId);

    if (userForEdit != null)
    {
        users.Remove(userForEdit);
        Console.WriteLine(" succesfully delted.");


    }
    else
        Console.WriteLine("didn't find a user with this userName");

    Console.ReadKey();
    Console.Clear();

}
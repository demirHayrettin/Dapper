using Dapper;
using Non_Query.Models;
using System.Data.SqlClient;

var connectionString = "Data Source=E;Initial Catalog=northwind;Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";
#region Insert
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    string sql = "INSERT INTO Customers (CustomerID, CompanyName, ContactName, City) VALUES (@CustomerID, @CompanyName, @ContactName, @City)";

//    var affectedRows = connection.Execute(sql, new { CustomerID = "NEWID", CompanyName = "New Company", ContactName = "New Contact", City = "New City" });

//    Console.WriteLine($"Inserted :  {affectedRows} rows");
//}
#endregion

#region Update
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    string sql = "UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID";

//    var affectedRows = connection.Execute(sql, new { CompanyName = "Updated Company", CustomerID = "NEWID" });

//    Console.WriteLine($"Updated :  {affectedRows} rows");
//}
#endregion

#region Delete
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    string sql = "DELETE Customers WHERE CustomerID = @CustomerID";

//    var affectedRows = connection.Execute(sql, new { CustomerID = "NEWID" });

//    Console.WriteLine($"Deleted :  {affectedRows} rows");
//}
#endregion

#region StoredProcedur
using (SqlConnection connection = new SqlConnection(connectionString))
{
    string storedProcedur = "GetCustomerByCity";
    var parameters = new { City = "London" };

    IEnumerable<Customer> customers = connection.Query<Customer>(storedProcedur, parameters, commandType: System.Data.CommandType.StoredProcedure);

    foreach (var customer in customers)
    {
        Console.WriteLine($"Customer ID: {customer.CustomerID}");
        Console.WriteLine($"Company Name: {customer.CompanyName}");
        Console.WriteLine($"Contact: {customer.ContactName}");
        Console.WriteLine(new string('-', 20));
    }
}
#endregion
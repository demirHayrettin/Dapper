using Dapper;
using Querying.Models;
using System.Data.SqlClient;

var connectionString = "Data Source=E;Initial Catalog=northwind;Integrated Security=True; Encrypt=True; TrustServerCertificate=True;";


#region Query
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    var sql = "SELECT ProductID, ProductName, UnitPrice FROM Products";
//    var products = connection.Query(sql).ToList();

//    Tüm ürünleri ve özelliklerini yazdırma
//    foreach (var product in products)
//    {
//        Console.WriteLine($"Ürün Adı: {product.ProductName}, Birim Fiyatı: {product.UnitPrice}");
//    }

//}
#endregion

//#region QuerySingle
//using (var connection = new SqlConnection(connectionString))
//{
//    var sql = "SELECT * FROM Products WHERE ProductID = 5";
//    var product = connection.QuerySingle(sql);

//    Console.WriteLine($"Product Name: {product.ProductName}, Unit Price: {product.UnitPrice} ");
//}
//#endregion

#region QuerySingle<T>
//using (var connection = new SqlConnection(connectionString))
//{
//    connection.Open();
//    var sql = "SELECT CustomerID, CompanyName, ContactName, City FROM Customers WHERE CustomerID = @CustomerID";
//    var customer = connection.QuerySingle<Customer>(sql, new { CustomerID = "ALFKI" });

//    Console.WriteLine(customer.CustomerID);
//    Console.WriteLine(customer.CompanyName);
//    Console.WriteLine(customer.ContactName);
//    Console.WriteLine(customer.City);
//}

#endregion

#region QueryMultiple

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();
    string sql = @"SELECT CustomerID, CompanyName, ContactName, City FROM Customers WHERE CustomerID = @CustomerID;            SELECT OrderID, CustomerID, OrderDate, ShipCity FROM Orders WHERE CustomerID =@CustomerID";
    using (var multi = connection.QueryMultiple(sql, new { CustomerID = "ALFKI" }))
    {
        var customer = multi.ReadSingle<Customer>();
        var orders = multi.Read<Order>();

        Console.WriteLine(customer.CustomerID);
        Console.WriteLine(customer.CompanyName);
        Console.WriteLine(customer.ContactName);
        Console.WriteLine(customer.City);

        foreach (var item in orders)
        {
            Console.WriteLine($"Order ID {item.OrderID}");
            Console.WriteLine($"Order Name {item.OrderDate}");
            Console.WriteLine($"Gönderim Şehri: {item.ShipCity}");
        }
    }

}
#endregion
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FirstLab
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnection connection = new DBConnection();
            List<Contracts> contracts = connection.GetContracts();
            contracts.ForEach(contract => Console.WriteLine(contract));
            Console.ReadKey();
        }
    }
}

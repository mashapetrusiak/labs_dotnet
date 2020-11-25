using _2lab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _2lab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProjectcontractsContext())
            {
                db.Employee
                    .Include(emp => emp.Address)
                    .Include(emp => emp.Characterization)
                    .Include(emp => emp.Project)
                    .Include(emp => emp.Fullname)
                    .Include(emp => emp.Position)
                    .ToList()
                    .ForEach(emp => Console.WriteLine($"{emp.Fullname.Lastname} {emp.Fullname.Firstname} " +
                    $"                                  {emp.Fullname.Surname} {emp.Address.City} " +
                    $"                                  {emp.Address.Street} {emp.Address.Home} " +
                    $"                                  {emp.Position.PositionName} {emp.Project.ProjectName} " +
                    $"                                  {emp.Project.ProjectStart} {emp.Project.ProjectEnd} " +
                    $"                                  {emp.Project.ProjectDescription} {emp.Characterization?.CharacterizationText ?? "Characterization not found"}" +
                    $"                                  {emp.Days} {emp.Salary}"));
                Console.ReadKey();
            }
        }
    }
}

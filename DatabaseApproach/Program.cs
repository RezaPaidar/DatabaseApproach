using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApproach
{
    public class Program
    {
        static void Main(string[] args)
        {
            //WriteCommand();
            Read_Data();
        }

        static void WriteCommand()
        {
            Console.WriteLine("Enter new team");
            var newTeam = Console.ReadLine();

            string query = "";

            var db = new AdoDotNet();
            int r = db.ExecuteCommand_To_SQLServer(query);
            if (r > 0)
            {
                Console.WriteLine("New team created successfully");
            }
            else
            {
                Console.WriteLine("Error number: " + r);
            }
        }

        static void Read_Data()
        {
            var query = $"SELECT CONCAT(c.CFirstName,' ' ,c.CFamilyName) AS cName FROM Coach c INNER JOIN CoachHistory ch ON c.Cid = ch.Cid INNER JOIN Teams t ON ch.Teamid = t.Teamid WHERE ch.Teamid = 1";

            var db = new AdoDotNet();
            var obj = db.Read_Opr(query);
            Console.WriteLine(obj.ToString());
        }

    }
}

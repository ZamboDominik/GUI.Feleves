using ConsoleTools;
using OSAHN6_HFT_202231.Models;
using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace OSAHN6_HFT_202231.Client
{
    class Program
    {
        static RestService rest;

        
        static void Main(string[] args)
        {
            /*NBADbContext NBA = new NBADbContext();
            TeamRepository team = new TeamRepository(NBA);
            TeamLogic tl = new TeamLogic(team);
            Console.WriteLine(tl.HighestSalary("Golden State Warriors"));
           
           
            foreach (var item in tl.PlayerListByPos("Dallas Maverics", "PG"))
            {
                Console.WriteLine(item);
            }
            foreach (var item in tl.ListPlayersCoachedBy("Steve Kerr"))
            {
                Console.WriteLine(item);
            }
            foreach (var item in tl.PositionStats())
            {
                Console.WriteLine(item);
            }
            foreach (var item in tl.StarPlayers())
            {
                Console.WriteLine(item);
            }
            // Console.WriteLine(tl.);*/
            rest = new RestService("http://localhost:5417/", "Team");
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var TeamMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Team>())
                .Add("Create", () => crud.Create<Team>())
                .Add("Delete", () => crud.Delete<Team>())
                .Add("Update", () => crud.Update<Team>())
                .Add("Exit", ConsoleMenu.Close);

            var PlayerSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Player>())
                 .Add("Create", () => crud.Create<Player>())
                 .Add("Delete", () => crud.Delete<Player>())
                 .Add("Update", () => crud.Update<Player>())
                 .Add("Exit", ConsoleMenu.Close);
            var CoachSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Coach>())
                .Add("Create", () => crud.Create<Coach>())
                .Add("Delete", () => crud.Delete<Coach>())
                .Add("Update", () => crud.Update<Coach>())
                .Add("Exit", ConsoleMenu.Close);

            var statsSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("StarPlayers", () => nonCrud.StarPlayers())
                 .Add("Position Stats", () => nonCrud.PosStats())
                 .Add("Players By Pos", () => nonCrud.PlayersByPos())
                 .Add("List Coached BY", () => nonCrud.ListCoachedBy())
                 .Add("Highest Salary On team", () => nonCrud.HighestSalary())
                 .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Teams", () => TeamMenu.Show())
                .Add("Players", () => PlayerSubMenu.Show())
                .Add("Coaches", () => CoachSubMenu.Show())
                .Add("Stats",() => statsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();


            ;
        }
    }
}

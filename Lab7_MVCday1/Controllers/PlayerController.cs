using Lab7_MVCday1.DataBase;
using Microsoft.AspNetCore.Mvc;
using Lab7_MVCday1.Models;
using Lab7_MVCday1.DTO;

namespace Lab7_MVCday1.Controllers
{
   

    public class PlayerController : Controller
    {
        private readonly AppDbContext appDbContext;

        public PlayerController()
        {
            appDbContext = new AppDbContext();
        }

        public IActionResult Index()
        {
            var result = appDbContext.players.Where(x => x.Is_Deleted == false).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SavePlayer(PlayerDTO pl)
        {
            if (pl.Name != null && pl.Age != 0 && pl.Email != null && pl.Password != null)
            {
                var player = new Player(pl.Name, pl.Age, pl.Email, pl.Password, "Admin");
                appDbContext.players.Add(player);
                appDbContext.SaveChanges();
                return RedirectToAction("Index", "Player");
            }
            return View("Create");
        }

        public IActionResult Edit(int id) 
        {
            var player = appDbContext.players.Where(p => p.PlayerID == id).FirstOrDefault();
            if (player == null)
            {

                ViewBag.Message = "Player Not Found";
                return View();
            }
            else
            {
                PlayerDTO playerDTO = new PlayerDTO()
                {
                    Name = player.Name,
                    Age = player.Age,
                    Email = player.Email,
                    Password = player.Password,
                    Id = player.PlayerID
                };
                return View(playerDTO);
            }
        }
        public IActionResult EditPlayer(PlayerDTO pl)
        {
            if (pl.Id == 0)
            {
                ViewBag.ErrorMessage = "Player not Found";
                return View("Edit", pl);
            }

            var player = appDbContext.players.FirstOrDefault(p => p.PlayerID == pl.Id);
            player.Edit(pl.Name, pl.Age, pl.Email, pl.Password);
            appDbContext.SaveChanges();
            return RedirectToAction("Index", "Player");
        }
        public IActionResult GetPlayer(int id) 
        {
            var player = appDbContext.players.Where(p => p.PlayerID == id).FirstOrDefault();
            if (player == null)
            {

                ViewBag.Message = "Player Not Found";
                return View();
            }
            else
            {
                PlayerDTO playerDTO = new PlayerDTO()
                {
                    Name = player.Name,
                    Age = player.Age,
                    Email = player.Email,
                    Password = player.Password,
                    Id = player.PlayerID
                };
                return View(playerDTO);
            }

        }
        public IActionResult Delete(int id) 
        {
            var player = appDbContext.players.Where(p => p.PlayerID == id).FirstOrDefault();
            if (player == null) 
            {
                ViewBag.Message = "Player Not Found";
                return View();
            }
            player.Delete();
            appDbContext.SaveChanges();
            return RedirectToAction("Index", "Player");
        }

        


    }
}

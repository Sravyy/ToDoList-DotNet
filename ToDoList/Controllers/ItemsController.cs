using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;


namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
       
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {   
            List<Item> model = db.Items.ToList();
            return View();
        }
        public IActionResult Details(int id)
        {
            Item thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }
    }
}

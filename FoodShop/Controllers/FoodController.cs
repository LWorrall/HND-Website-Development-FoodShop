using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodShop.Models;
using FoodShop.Data;

namespace FoodShop.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            List<FoodModel> food = new List<FoodModel>();

            FoodDAO foodDAO = new FoodDAO();
            food = foodDAO.GetAll();

            return View("index", food);
        }

        public ActionResult Details(int Id)
        {
            FoodModel food = new FoodModel();
            
            FoodDAO foodDAO = new FoodDAO();
            food = foodDAO.GetOne(Id);
            
            return View("Details", food);
        }

        public ActionResult Create()
        { return View("FoodForm"); }

        public ActionResult ProcessCreate(FoodModel foodModel)
        {
            FoodDAO foodDAO =new FoodDAO();
            foodDAO.Create(foodModel);

            return View("Details", foodModel);
        }

        public ActionResult Edit(int Id)
        {
            FoodDAO foodDAO =new FoodDAO();
            FoodModel food = foodDAO.GetOne(Id);

            return View("FoodForm2", food);
        }

        public ActionResult Delete(int Id)
        {
            FoodDAO foodDAO=new FoodDAO();
            foodDAO.Delete(Id);
            List<FoodModel> food = foodDAO.GetAll();

            return View("Index", food);
        }

        public ActionResult SearchForm()
        { return View("SearchForm"); }

        public ActionResult SearchForName(string searchPhrase)
        {
            // Get a list of search results from the database.
            FoodDAO foodDAO = new FoodDAO();
            List<FoodModel> searchResults = foodDAO.SearchForName(searchPhrase);

            return View("Index", searchResults);
        }
    }
}
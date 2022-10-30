using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller            /*Inne i controller, du vil at ApplicationDbCintext skal jobbe med Database*/
    {
        private readonly ApplicationDbContext _db;          /*lage en private felt med ApplicationDbCintext.*/
                                                            /*aktivere using statement "BulkyBookWeb.Data".*/
                                                            /*og gi det ApplicationDbContext navnet _Db.*/
        public CategoryController(ApplicationDbContext db)  /*Så den Db vil ha all implementasjon av koblingsstrenger.*/
                                                            /*og tabeller som trengs for å hente data.*/
                                                            /*Slik vil vi fylle opp vår lokale DbObjekt med denne implementasjonen.*/
        {
            _db = db;                                       /*Be om at _db er det samme som db.*/
                                                            /*Så kan vi bruke denne _db til å hente våre "Categories".*/
        }

        public IActionResult Index()    /*Index action metode.*/
        {                                                                           /*var objCategoryList = _db.Categories.ToList(); var forrige kode som ble endret til IEnumerable.*/
            IEnumerable<Category> objCategoryList = _db.Categories;                 /*lage en (variabel) "var" som vi kaller "objCategoryList som vil først gå til/få adgang til _db.*/
          /*Endret fra "var" metode til "IEnumerable" metode*/                      /*Og på den vil vi ha alle DbSet. DbSet Som vi vil jobbe med er Categories.*/
 /*slik at vi overfører IEnumerable av vår CategoriListe til View*/                 /*Og vi vil konvertere det til en liste og hente det.*/
         /*Så må vi fange det inne i Vår View også/på siden*/                       /*Så den vil gå til Databsen og hente alle Categories og gjøre det om til en liste.*/
         /*som blir da i vår Views mappe, Category og Index.cshtml*/
            
            return View(objCategoryList);                   /*Nå som vi har alle Categories inne i denne objectCategoryList,*/
                                                            /*så kan vi kopiere det og lime det inni vår View(), slik: View(objCategoryList)*/
                                                            /*for at det skal vises på siden.*/
        }
    }
}

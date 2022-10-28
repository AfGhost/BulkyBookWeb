using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;          /*lage en private felt med ApplicationDbCintext.*/
                                                            /*aktivere using statement "BulkyBookWeb.Data".*/
                                                            /*og gi det ApplicationDbContext navnet _Db.*/
        public CategoryController(ApplicationDbContext db)  /*Så den Db vil ha all implementasjon av koblingsstrenger.*/
                                                            /*og tabeller som trengs for å hente data.*/
                                                            /*Slik vil vi fylle opp vår lokale DbObjekt med denne implementasjonen.*/
        {
            _db = db;                                       /*Be om at _db er det samme som db.*/
                                                            /*Så kan vi bruke denn _db til å hente våre "Categories".*/
        }

        public IActionResult Index()    /*Index action metode.*/
        {
            var objCategoryList = _db.Categories.ToList();  /*lage en (variabel) "var" som vi kaller "objCategoryList som vil først gå til/få adgang til _db.*/
                                                            /*Og på den vil vi ha alle DbSet. DbSet Som vi vil jobbe med er Categories.*/
                                                            /*Og vi vil konvertere det til en liste og hente det.*/
                                                            /*Så den vil gå til Databsen og hente alle Categories og gjøre det om til en liste.*/
            return View();
        }
    }
}

using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


//INDEX!!!

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

        //GET (Get action method)                           /*Når noen trykke på knappen "Create" skal de få mulighet til å skrive ting inn*/
        public IActionResult Create()                       /*så når View blir lastet inn, så trenger den ikke å gjennom Model*/
        {                                                   
            return View();                                  /*Dermed kan du ha return View () blank og så kan du opprette en Model direkte inne i View*/
                                            /*Ved å høyre klikke på "Create" -> "Add View" -> "Razor View, så Add*/
                                            /*Da vil ny View med navnet "Create" opprettes i View mappen, under Category, som blir da "Create.cshtml"*/
        }


//CREATE!!!

        //POST (POST action method)
        [HttpPost]                          /*Hvis en POST action method er brukt, så må vi skrive HttpPost etter.*/
        [ValidateAntiForgeryToken]          /*Er lurt å bruke på POST for å unngå forespørselsforfalskning på tvers av nettsider (the cross site request forgery)*/
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            } 

            if (ModelState.IsValid)                     /*Hvis den er Valid, vil Redirect til Index, hvis den er ikke Valid, */
            {
                _db.Categories.Add(obj);                /*for henting,trengte vi ikke å skrive noe annet, men for å legge til "Categories" inne i databasen forventer den en entity som vi har inne i "obj"*/
                _db.SaveChanges();                      /*den blir ikke "pushed" til databasen før vi bruker "lagring" kommandoen, _db.SaveChanges*/
                return RedirectToAction("Index");       /*med "return View();" når alle endringer er lagret, så har vi View her som vi ta oss tilbake til samme Category View.*/
            }
                                                        /*Men la oss si at når vi er ferdig, så skal vi gå tilbake til samme Index så vi kan se det nye Category som var opprette*/
                                                        /*Så istedenfor "return View", skal vi omdirigere til en "action", og det vil vi til en Index action som er litt lenger oppe (Index Action Method)*/
                                                        /*Den vil se etter Index inne i samme controller. Hvis du måtte gå til en annen Acton method i en annen controller, så kunne du skrive en controller navn etter Index etter komma*/
                                                        /*Men siden vi er i samme controller, så trenger vi kun å Index her.*/
            
            return View(obj);                           /*Hvis den er IKKE Valid, vil den returnere tilbake til View med "obj"*/
        }


//EDIT - GET!!!

        //GET (Get action method)                           /*Når noen trykke på knappen "Edit" skal de få mulighet til å redigere ting inn*/
        public IActionResult Edit(int? id)                         /*så når View blir lastet inn, så trenger den ikke å gjennom Model*/
        {
            if(id==null || id == 0)                                 /*Hvis ID er null eller ID er 0*/
            {
                return NotFound();                                          /*Så skal return bli "NotFound"*/
            }                                                               /*Hvis det er ikke tilfelle og ID blir riktig lagt inn, så skal vi hente Category fra databasen "CategoryFromDb*/
            var categoryFromDb = _db.Categories.Find(id);                   /*Variable categoryFromDb er lik vår _db.Categories og finne "id"*/
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)                             /*Hvis Category fra Db er NULL*/
            {
                return NotFound();                                  /*Så skal return bli "NotFound"*/
            }

            return View(categoryFromDb);                            /*Hvis vi finner den Category, så skal den returneres til View.*/
                                                                    /*Så neste skal vi lage en View som vil ha Category Loaded og vi trenger å vise det som er funnet.*/
                                                                    /*For det må vi lage en View som heter Edit. Den vil se helt lik ut som Create View*/
                                                                    /*Eneste forskjellen vil bli at det vil være for Edit siden.*/

        }


//EDIT - POST!!!

        //POST (POST action method)
        [HttpPost]                                          /*Hvis en POST action method er brukt, så må vi skrive HttpPost etter.*/
        [ValidateAntiForgeryToken]                          /*Er lurt å bruke på POST for å unngå forespørselsforfalskning på tvers av nettsider (the cross site request forgery)*/
        public IActionResult Edit(Category obj)             /*Action metode til Edit Category Obj*/
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }

            if (ModelState.IsValid)                         
            {
                _db.Categories.Update(obj);                 /*Siden dette er for Edit, så trenger vi ikke "Add", men "Update" for å endre i CategoryDb*/         
                _db.SaveChanges();                          
                return RedirectToAction("Index");           
            }

            return View(obj);                               
        }


//DELETE - GET!!!

        //GET (Get action method)                           /*Når noen trykke på knappen "Edit" skal de få mulighet til å redigere ting inn*/
        public IActionResult Delete(int? id)                         /*så når View blir lastet inn, så trenger den ikke å gjennom Model*/
        {
            if (id == null || id == 0)                                 /*Hvis ID er null eller ID er 0*/
            {
                return NotFound();                                          /*Så skal return bli "NotFound"*/
            }                                                               /*Hvis det er ikke tilfelle og ID blir riktig lagt inn, så skal vi hente Category fra databasen "CategoryFromDb*/
            var categoryFromDb = _db.Categories.Find(id);                   /*Variable categoryFromDb er lik vår _db.Categories og finne "id"*/
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)                             /*Hvis Category fra Db er NULL*/
            {
                return NotFound();                                  /*Så skal return bli "NotFound"*/
            }

            return View(categoryFromDb);                            /*Hvis vi finner den Category, så skal den returneres til View.*/
            /*Så neste skal vi lage en View som vil ha Category Loaded og vi trenger å vise det som er funnet.*/
            /*For det må vi lage en View som heter Edit. Den vil se helt lik ut som Create View*/
            /*Eneste forskjellen vil bli at det vil være for Edit siden.*/

        }

        
//DELETE - POST!!!

        //POST (POST action method)
        [HttpPost, ActionName("Delete")]                    /*Hvis en POST action method er brukt, så må vi skrive HttpPost etter.*/
        [ValidateAntiForgeryToken]                          /*Er lurt å bruke på POST for å unngå forespørselsforfalskning på tvers av nettsider (the cross site request forgery)*/
        public IActionResult DeletePOST(int? id)            /*/Vi kan ikke ha samme "Delete(int? id)" som i GET method, derfor endrer vi navnet her til "DeletePOST" istedet. Action metode til Delete Category Obj. Action method will pass the int id.*/
        {
            var obj = _db.Categories.Find(id);              /*Basert på id, vil vi hente Category, så som en vaiabel obj = _db.Categories.Find, basert på (id), vilvi finne "obj" og*/
            if (obj == null)                                /*Hvis den er "null", så vil vi returnere: */
            {
                return NotFound();                          /*"NotFound",*/
            }
            
                _db.Categories.Remove(obj);                 /*Ellers, på _db.Categories vil vi ha "Remove" som vil fjerne variabel "obj", istedenfor "Update" eller "Add" som vi brukte tidligere.*/    
                _db.SaveChanges();                          /*Endringer vil lagres og*/
                return RedirectToAction("Index");           /*Dirigere tilbake til "Index" siden.*/     
                                                            /*Så kan vi lage en "Delete VIEW" for Delete akkurat sin vi gjorde for "Create" og "Edit"*/

         
        }

    }
}

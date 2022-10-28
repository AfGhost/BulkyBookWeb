using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;                                                        /*using statement "Microsoft.EntityFrameworkCore" legges til her for at den skal brukes*/
                                                                                            /*av KLASSEN "ApplicationDbContext" og OBJEKTET "DbContext"*/
                                                                                        /*Lage en mappe "Data" under BulkyBookWeb for alle data relaterte endringer.*/
namespace BulkyBookWeb.Data                                                             /*Lage "ApplicationbDbContext" KLASSE i "Data" mappe, for å fortelle vår app om at vi skal bruke SQL og*/
{                                                                                       /* at vi skal bruke denne koblingsstrengen i "appsettings.json" for å koble oss til vår SQL database.*/
                                                                                        /*For å gjøre det, skal vi bruke Entityframeworkcore og opprette en objekt av "DbContext"*/
                                                                                        /*Ved å bruke denne "DbContext" objektet vil vi kunne koble oss til Databasen.*/
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  /*Lage en "constructor" --> "ApplicationDbContext" ved å bruke snarveien "ctor"*/
                                                                                                      /*Henviser til base(options) som ligger i "Services" i "Program.cs" og blir definert der om hva "options" er.*/
        {
        }

        public DbSet<Category> Categories { get; set; }                                     /*Lage en DbSet og henvise til Category modell.*/
                                                                                            /*Bruke "using BulkyBookWeb.Models" helt øverst for å si til dokumentet at at "Category" modell ligger i Models.*/
                                                                                            /*Lage en tabell inne i denne Databasen som vil hete "Categories" som får Get/Set.*/
                                                                                        /*Denne vil lage en "Category" tabell med navnet "Categories" og den vil ha 4 kolonner som finnes i Category Model med en Id som PK*/
                                                                                        /*Når man jobber med EntityFrameWork, det er modeller. En er "Kode" først og en er "DataBase" først. Dette her er "Kode" først.*/
                                                                                        /*Atså vi lager modeller først, så basert på modellen, så lager vi Databasen utifra det igjen.*/

                                                                                /*Nå må vi forteller vår applikasjon at den må bruke DbContext, som er inne i ApplicationDbContext og at den må bruke SQL server*/
                                                                                /*ved å bruke koblingsstrengen som ligger inne i appsettings.json.*/
                                                                                /*Dette gjør vi inne i "Program.cs" hvor vi vil konfigurere tjenester "Services" som applikasjonen skal bruke.*/
    }
}

using Microsoft.EntityFrameworkCore;

namespace ExcelProject.Models
{
    public class CGetXName
    {
        internal IEnumerable<tCity> getCity()
        {
            using (NewPetContext db = new NewPetContext(new DbContextOptions<NewPetContext>()))
            {
                var q = db.tCities.OrderBy(m => m.fCityID);
                return q.ToList(); ;
            }
        }

        internal IEnumerable<tRegion> getRegion(string cityid)
        {
            using (NewPetContext db = new NewPetContext(new DbContextOptions<NewPetContext>()))
            {
                var q = db.tRegions.Where(m => m.fCityID.ToString() == cityid);
                return q.ToList();
            }
        }

        internal IEnumerable<tPetClass> getPetClass()
        {
            using (NewPetContext db = new NewPetContext(new DbContextOptions<NewPetContext>()))
            {
                var q = db.tPetClasses;
                return q.ToList();
            }
        }

        internal IEnumerable<tBreed> getBreed(string petclassid)
        {
            using (NewPetContext db = new NewPetContext(new DbContextOptions<NewPetContext>()))
            {
                var q = db.tBreeds.Where(m => m.fPetClassID.ToString() == petclassid);
                return q.ToList();
            }
        }
    }
}
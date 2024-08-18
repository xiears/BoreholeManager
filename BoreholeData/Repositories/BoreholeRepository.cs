using BoreholeData.Entities;

namespace BoreholeData.Repositories
{
    public class BoreholeRepository
    {
        private BoreholeContext context;

        public BoreholeRepository(BoreholeContext bhContext) 
        { 
            context = bhContext;
        }

        public int Add (Borehole bh)
        {
            context.Add (bh);
            context.SaveChanges();

            return bh.ID;
        }

        public void Edit (Borehole bh)
        {
            context.Update (bh);
            context.SaveChanges();
        }

        public void Delete (int id)
        {
            var borehole = GetById(id);
            context.Remove (borehole);
            context.SaveChanges();
        }

        public Borehole GetById(int id)
        {
            return context.Boreholes.Where(bh => bh.ID == id).FirstOrDefault();
        }

        public List<Borehole> GetAll()
        {
            return context.Boreholes.ToList();
        }

        public List<Borehole> GetByArea(int x1, int y1, int x2, int y2)
        {
            return context.Boreholes.Where(bh => (bh.X >= x1 && bh.X <= x2 && bh.Y >= y1 && bh.Y <= y2)).ToList();
        }
    }
}

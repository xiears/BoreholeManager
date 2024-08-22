using BoreholeData.Entities;
using Microsoft.Extensions.Logging;

namespace BoreholeData.Repositories
{
    public class BoreholeRepository
    {
        private BoreholeContext context;
        private ILogger logger;

        public BoreholeRepository(BoreholeContext bhContext, ILogger log)
        { 
            context = bhContext;
            logger = log;
        }

        public int Add (Borehole bh)
        {
            try
            {
                logger.LogInformation($"Saving a borehole {bh}");

                context.Add(bh);
                context.SaveChanges();

                return bh.ID;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error saving Borehole - {ex}");
            }

            return 0;
        }

        public void Edit (Borehole bh)
        {
            try
            {
                logger.LogInformation($"Saving changes to a borehole {bh}");

                context.Update (bh);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error saving Borehole - {ex}");
            }
        }

        public void Delete (int id)
        {
            try
            {
                logger.LogInformation($"Deleting borehole with id {id}");

                var borehole = GetById(id);
                context.Remove(borehole);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error deleting Borehole - {ex}");
            }
        }

        public Borehole GetById(int id)
        {
            logger.LogInformation($"Getting borehole with id {id}");

            return context.Boreholes.Where(bh => bh.ID == id).FirstOrDefault();
        }

        public List<Borehole> GetAll()
        {
            logger.LogInformation($"Getting all boreholes");
            return context.Boreholes.ToList();
        }

        public List<Borehole> GetByArea(int x1, int y1, int x2, int y2)
        {
            logger.LogInformation($"Getting all boreholes in area ({x1},{y1}),({x2},{y2});
            return context.Boreholes.Where(bh => (bh.X >= x1 && bh.X <= x2 && bh.Y >= y1 && bh.Y <= y2)).ToList();
        }
    }
}

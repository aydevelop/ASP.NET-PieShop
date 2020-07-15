using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        IEnumerable<Pie> IPieRepository.AllPies
        {
            get
            {
                return _appDbContext.Pies
                    .Include(q => q.Category);
            }
        }

        IEnumerable<Pie> IPieRepository.PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies
                    .Include(q => q.Category)
                    .Where(q => q.IsPieOfTheWeek);
            }
        }

        Pie IPieRepository.GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(q => q.PieId == pieId);
        }
    }
}

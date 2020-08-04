namespace CSICorpHelpDesk.Data.Repository
{
    using Model;

    public class UnitRepository : IUnitRepository
    {
        private ApplicationDbContext _context;
        private BaseRepository<Author> author;
        public UnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Author> Authors
        {
            get
            {
                return author ?? (author = new BaseRepository<Author>(_context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
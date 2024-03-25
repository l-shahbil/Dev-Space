using Dev_space.Data;
using Dev_space.Models;

namespace Dev_space.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            accounts = new MainRepository<Account>(_context);
            posts = new MainRepository<Post>(_context);
            tags = new MainRepository<Tag>(_context);
            friends = new MainRepository<Friend>(_context);
            links = new MainRepository<Link>(_context);
            commints = new MainRepository<Commint>(_context);
            links = new MainRepository<Link>(_context);
            imgs = new MainRepository<Img>(_context);
            codes = new MainRepository<Code>(_context);
            archives = new MainRepository<Archive>(_context);
        }
        public MainRepository<Account> accounts { get;private set;}

        public MainRepository<Post> posts { get; private set; }

        public MainRepository<Tag> tags { get; private set; }

        public MainRepository<Friend> friends { get; private set; }

        public MainRepository<Link> links { get; private set; }

        public MainRepository<Commint> commints { get; private set; }

        public MainRepository<Like> likes { get; private set; }

        public MainRepository<Img> imgs { get; private set; }

        public MainRepository<Code> codes { get; private set; }

        public MainRepository<Archive> archives { get; private set; }

        public int CommitChange()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using Dev_space.Models;
using System;

namespace Dev_space.Repository.Base
{
    public interface IUnitOfWork:IDisposable
    {
        MainRepository<Account> accounts { get; }
        MainRepository<Post> posts { get; }
        MainRepository<Tag> tags { get; }   
        MainRepository<Friend> friends { get; }
        MainRepository<Link> links { get; }
        MainRepository<Commint> commints { get; }
        MainRepository<Like> likes  { get; }
        MainRepository<Img> imgs { get; }
        MainRepository<Code> codes { get; }
        MainRepository<Archive> archives { get; }

        int CommitChange();
    }
}

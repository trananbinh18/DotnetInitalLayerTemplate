using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<PostEntity>> GetPostsAsync(string searchText); 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.VisualBasic;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories.Implementations
{
    public class PostRepository : IPostRepository
    {
        private readonly List<PostEntity> _postEntities = new List<PostEntity>(){
            new PostEntity{
                Id = "1",
                Title = "Some",
                Description = "hello world"
            },
            new PostEntity{
                Id = "2",
                Title = "We from the hood",
                Description = "hello world"
            },
            new PostEntity{
                Id = "3",
                Title = "Love the thing",
                Description = "this is the thing"
            },
            new PostEntity{
                Id = "1",
                Title = "Some thing",
                Description = "some thing"
            }
        };

        public async Task<List<PostEntity>> GetPostsAsync(string searchText)
        {
            if(string.IsNullOrEmpty(searchText)) {
                return _postEntities;
            }
            
            await Task.Delay(200);
            return _postEntities.Where(x => x.Title.Contains(searchText)).ToList();
        }
    }
}
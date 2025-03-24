using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<PostResponse>> GetPostsAsync(string searchText);
    }
}
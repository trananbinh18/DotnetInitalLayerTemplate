using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using Persistence.Repositories.Interfaces;

namespace Application.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _autoMapper;
        public PostService(IPostRepository postRepository, IMapper mapper) {
            _postRepository = postRepository;
            _autoMapper = mapper;
        }

        public async Task<List<PostResponse>> GetPostsAsync(string searchText)
        {
            var result = await _postRepository.GetPostsAsync(searchText);
            var response = _autoMapper.Map<List<PostResponse>>(result);
            await Task.Delay(100);
            return  response;
        }
    }
}
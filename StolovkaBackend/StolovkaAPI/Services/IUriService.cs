using System;
using StolovkaWebAPI.Contracts.V1.Requests.Queries;

namespace StolovkaWebAPI.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);

        Uri GetAllPostsUri(PaginationQuery pagination = null);
    }
}
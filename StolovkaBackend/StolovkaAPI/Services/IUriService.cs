using StolovkaWebAPI.Contracts.V1.Requests.Queries;
using System;

namespace StolovkaWebAPI.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);

        Uri GetAllPostsUri(PaginationQuery pagination = null);
    }
}
using System;

namespace StolovkaWebAPI.Services
{
    public interface IUriService
    {

        Uri GetPostUri(string postId);
    }
}
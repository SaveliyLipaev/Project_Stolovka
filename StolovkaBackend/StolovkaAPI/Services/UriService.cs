using Microsoft.AspNetCore.WebUtilities;
using StolovkaWebAPI.Contracts.V1;
using System;

namespace StolovkaWebAPI.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostUri(string postId)
        {
            return null;//new Uri(_baseUri + ApiRoutes.Canteens.Get.Replace("{postId}", postId));
        }
    }
}
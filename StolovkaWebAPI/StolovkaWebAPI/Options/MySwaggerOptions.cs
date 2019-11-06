namespace StolovkaWebAPI.Options
{
    public class MySwaggerOptions
    {
        public string JsonRoute { get; set; } = "swagger/{documentName}/swagger.json";

        public string Description { get; set; }

        public string UIEndpoint { get; set; } = "/swagger/v1/swagger.json";
    }
}
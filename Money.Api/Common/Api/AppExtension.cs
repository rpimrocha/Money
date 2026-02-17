namespace Money.Api.Common.Api
{
    public static class AppExtension
    {
        public static void AtivarSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }

        public static void AtivarSeguranca(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
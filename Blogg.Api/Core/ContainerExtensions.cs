using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.Email;
using Blog.Application.Queries;
using Blog.DataAccess;
using Blog.Implementation.Commands;
using Blog.Implementation.Email;
using Blog.Implementation.Logging;
using Blog.Implementation.Queries;
using Blog.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogg.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            
            services.AddTransient<ICreateUserCommand, EFAddUser>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUser>();
            services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();
            services.AddTransient<IGetPostQuery, EFGetPostQuery>();
            services.AddTransient<ICreatePostCommand, EFCreatePostCommand>();
            services.AddTransient<IDeletePostComman, EFDeletePostCommand>();
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCommandCategory>();
            services.AddTransient<ICreateMenuCommand, EFCreateMenuCommand>();
            services.AddTransient<IDeleteMenuCommand, EFDeleteMenuCommand>();
            services.AddTransient<ICreateCommentCommand, EFCreateCommentCommand>();
            services.AddTransient<IDeleteCommnetCommand, EFDeleteCommentCommand>();
            services.AddTransient<IEditCommentCommand, EFEditCommentCommand>();
            services.AddTransient<IEditCategoryCommand, EFEditCategoryCommand>();
            services.AddTransient<IEditMenuCommand, EFEditMenuCommand>();
            services.AddTransient<IEditUserCommand, EFEditUserCommand>();
            services.AddTransient<ICreatePictureCommand, EFCreatePictureCommand>();
            services.AddTransient<IDeletePictureCommand, EFDeletePictureCommand>();
            services.AddTransient<IEmailSender, SMtpEmailSender>();
            services.AddTransient<IEditPostCommand, EFEditPostCommand>();
            services.AddTransient<IGetCategoriesQuery, EFGetCategoryQuery>();
            services.AddTransient<IGetCommentQuery, EFGetCommentQuery>();
            services.AddTransient<IGetMenuQuery, EFGetMenuQuery>();
         
            services.AddTransient<IGetPostQuery, EFGetPostQuery>();
            services.AddTransient<IGetOneCategoryQuery, EFGetOneCategoryQuery>();
            services.AddTransient<IGetOneCommentQuery, EFGetOneCommentQuery>();
            services.AddTransient<IGetOneMenuQuery, EFGetOneMenuQuery>();
            services.AddTransient<IGetOneUserQuery, EFGetOneUser>();
            services.AddTransient<IGetPostQuery, EFGetPostQuery>();
            services.AddTransient<IGetOnePostQuery, EFGetOnePostQuery>();
           

            services.AddTransient<CreateUserValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CategoryValidator>();
            services.AddTransient<DeleteCategoryValidator>();
            services.AddTransient<CreatePictureValidator>();
            services.AddTransient<DeletePictureValidator>();
            services.AddTransient<CreateCommentValidator>();
        

        }
        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();


                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnnonymusActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }
        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<BlogContext>();

                return new JwtManager(context);
            });
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}

using AutoMapper;
using EnStudy.BLL.Dto;
using EnStudy.Models;
using EnStudy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EnStudy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Mapping配置
            MappingConfig.RegisterMaps();
        }

        /// <summary>
        /// Auto Mapping
        /// </summary>
        public static class MappingConfig
        {
            public static void RegisterMaps()
            {
                Mapper.Initialize(config =>
                {
                    //注册用户Mapper
                    config.CreateMap<IUserReistInput, User>();
                    config.CreateMap<IUserUpdateInput, User>();
                    config.CreateMap<User, UserViewModel>();

                    //学习计划
                    config.CreateMap<StudySchedue, StudySchedueVieModel>();
                    config.CreateMap<IStudySchedueInput, StudySchedue>();

                    config.CreateMap<SpeakComents, UserSpeakComentViewModel>();

                    config.CreateMap<StudyNotesType, StudyNoteTypeOutput>();

                    config.CreateMap<StudyNodes, StudyNotesBriefOuput>();

                    config.CreateMap<StudySchedue, StudySchedueVieModel>();
                    config.CreateMap<StudyNodes, StudyNotesOutput>()
                    .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.StudyNotesType.Id));

                    config.CreateMap<StudyNotesInput, StudyNodes>();
                    config.CreateMap<UserMovie, UserMovieViewModel>();
                });
            }

        }
    }
}

using Autofac;
using DotNetRuServer.Comon.BL.Caching;
using DotNetRuServer.Comon.BL.Config;
using DotNetRuServer.Meetups.BL.Interfaces;
using DotNetRuServer.Meetups.BL.Services;

namespace DotNetRuServer.Meetups.BL
{
    public class MeetupModule<TSpeakerProvider, TTalkProvider, TVenueProvider, TFriendProvider, TMeetupProvider, TCommunityProvider, TImageProvider> : Module
        where TSpeakerProvider : ISpeakerProvider
        where TTalkProvider : ITalkProvider
        where TVenueProvider : IVenueProvider
        where TFriendProvider : IFriendProvider
        where TMeetupProvider : IMeetupProvider
        where TCommunityProvider : ICommunityProvider
        where TImageProvider : IImageProvider
    {
        private const string PureImplementation = nameof(PureImplementation);

        private readonly Settings _settings;

        public MeetupModule(Settings settings)
        {
            _settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => _settings).AsSelf().SingleInstance();

            builder.RegisterType<TSpeakerProvider>().As<ISpeakerProvider>().SingleInstance();
            builder.RegisterType<SpeakerService>().Named<ISpeakerService>(PureImplementation);
            builder.RegisterDecorator<ISpeakerService>(
                    (c, inner) => new CachedSpeakerService(c.Resolve<ICache>(), inner), PureImplementation)
                .SingleInstance();

            builder.RegisterType<TTalkProvider>().As<ITalkProvider>().SingleInstance();
            builder.RegisterType<TalkService>().Named<ITalkService>(PureImplementation);
            builder.RegisterDecorator<ITalkService>(
                    (c, inner) => new CachedTalkService(c.Resolve<ICache>(), inner), PureImplementation)
                .SingleInstance();

            builder.RegisterType<TVenueProvider>().As<IVenueProvider>().SingleInstance();
            builder.RegisterType<VenueService>().Named<IVenueService>(PureImplementation);
            builder.RegisterDecorator<IVenueService>(
                    (c, inner) => new CachedVenueService(c.Resolve<ICache>(), inner), PureImplementation)
                .SingleInstance();

            builder.RegisterType<TFriendProvider>().As<IFriendProvider>().SingleInstance();
            builder.RegisterType<FriendService>().Named<IFriendService>(PureImplementation);
            builder.RegisterDecorator<IFriendService>(
                    (c, inner) => new CachedFriendService(c.Resolve<ICache>(), inner), PureImplementation)
                .SingleInstance();

            builder.RegisterType<TImageProvider>().As<IImageProvider>().SingleInstance();
            builder.RegisterType<ImageService>().As<IImageService>().SingleInstance();

            builder.RegisterType<TMeetupProvider>().As<IMeetupProvider>().SingleInstance();
            builder.RegisterType<MeetupService>().Named<IMeetupService>(PureImplementation);
            builder.RegisterDecorator<IMeetupService>(
                    (c, inner) => new CachedMeetupService(c.Resolve<ICache>(), inner), PureImplementation)
                .SingleInstance();
            
            builder.RegisterType<TCommunityProvider>().As<ICommunityProvider>().SingleInstance();
            builder.RegisterType<CommunityService>().Named<ICommunityService>(PureImplementation);
        }
    }
}
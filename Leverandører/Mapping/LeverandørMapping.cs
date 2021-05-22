namespace Leverandører.Mapping
{
    public class LeverandørMapping : AutoMapper.Profile
    {
        public LeverandørMapping()
        {
            CreateMap<Db.Leverandør, Models.Leverandør>();
            CreateMap<Models.Leverandør, Db.Leverandør>();
        }
    }
}